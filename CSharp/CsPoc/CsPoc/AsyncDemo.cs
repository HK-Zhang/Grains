using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CSDemo
{
    class AsyncDemo
    {
        Func<string, string> func;

        public void Run()
        {
            //CallViaDelegate();
            //CallViaDelegateSync();
            CallViaEvent();
        }



        private string Foo(string msg) 
        {
            Console.WriteLine("foo start");
            Thread.Sleep(3000);
            Console.WriteLine("foo end");
            return "done";
        }

        private void CallViaDelegate()
        {
            func = Foo;
            func.BeginInvoke("HelloWorld", CallViaDelegateCallback, "This is parameter for callback");
            Console.WriteLine("keep working");

        }

        private void CallViaDelegateSync()
        {
            func = Foo;
            IAsyncResult ar = func.BeginInvoke("HelloWorld", null, null);
            func.EndInvoke(ar);
            Console.WriteLine("keep working");

        }

        private void CallViaDelegateCallback(IAsyncResult ar)
        {
            string str = (string)ar.AsyncState;
            Func<string, string> func = (ar as AsyncResult).AsyncDelegate as Func<string, string>;
            string result = func.EndInvoke(ar);
            Console.WriteLine(str);
            Console.WriteLine("Callback get result:"+result);


        }

        private void CallViaEvent()
        {
            MyAsyncClient<string, string> client = new MyAsyncClient<string, string>();
            client.OnCallCompleted += client_OnCallCompleted;
            Console.WriteLine("keep working");
            client.CallAysnc("P1", "P2");
        }

        void client_OnCallCompleted(object sender, MyAsyncClient<string, string>.CallCompletedEventArgs e)
        {
            Console.WriteLine("completed;"+e.Result);
        }



    }

    sealed class MyAsyncClient<TIn,TOut>
    {
        private volatile bool _isBusy;
        public bool IsBusy { get { return _isBusy; } }
        private Action<TIn, TOut, Exception, object> act;

        public delegate void CallCompletedEventHandler(object sender, CallCompletedEventArgs e);
        public event CallCompletedEventHandler OnCallCompleted;

        public class CallCompletedEventArgs:AsyncCompletedEventArgs
        {
            private TOut _result;
            public TOut Result 
            {
                get
                { 
                    RaiseExceptionIfNecessary();
                    return _result;
                }
            }

            public CallCompletedEventArgs(TOut result, Exception e, bool canceled, object state)
                : base(e, canceled, state)
            {
                _result = result;
            }

        }

        private void Foo(TIn msg, Action<TOut, Exception, object> callback, AsyncOperation asyncOp)
        {
            Console.WriteLine("foo start");
            Thread.Sleep(3000);
            Console.WriteLine("foo end");
            callback((TOut)Convert.ChangeType("end",typeof(TOut)), null, asyncOp);
            //callback((TOut)"", null, asyncOp);
        }

        public void CallAysnc(TIn input, object state)
        {

            if (input == null)
                throw new ArgumentNullException("input");

            if (_isBusy)
                throw new InvalidOperationException("client is busy.");

            // 准备与同步上下文有关的对象
            // 注意这个调用，这是整个事件模式的核心。
            AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(state);

            //---------------------------------------------------------------------------------
            // 注意：
            //   这个客户端的封装类其实可以算是个辅助类，整个类就是辅助下面的这个调用。
            //   这个类其实只处理二个简单的功能：
            //     1. 引发异步调用完成后的事件。
            //     2. 在合适的同步上下文环境中引发完成事件。
            //   而真正发送请求的过程，在下面这个方法中实现的。

            // 开始异步调用。这个方法将完成发送请求的过程。第三个参数为回调方法。
            //HttpWebRequestHelper<TIn, TOut>.SendHttpRequestAsync(_url, input, CallbackProc, asyncOp);
            //Func<string, string> func = Foo;
            //func.BeginInvoke("HelloWorld", CallbackProc, asyncOp);
            Thread thread = new Thread(() => Foo(input, CallbackProc, asyncOp));
            thread.Start();  

            _isBusy = true;
        }

        // 异步完成的回调方法
        private void CallbackProc(TOut result, Exception exception, object state)
        {
            // 进入这个方法表示异步调用已完成。

            AsyncOperation asyncOp = (AsyncOperation)state;

            // 创建事件参数
            CallCompletedEventArgs e =
                new CallCompletedEventArgs(result, exception, false /* canceled */, asyncOp.UserSuppliedState);

            // 切换线程调用上下文。注意第一个参数为回调方法。
            asyncOp.PostOperationCompleted(CallCompleted, e);
        }

        // 用于处理完成后同步上下文切换的回调方法
        private void CallCompleted(object args)
        {
            // 运行到这里表示已经切回当初发起调用CallAysnc()时的同步上下文环境。

            CallCompletedEventArgs e = (CallCompletedEventArgs)args;

            // 引发完成事件
            CallCompletedEventHandler handler = OnCallCompleted;
            if (handler != null)
                handler(this, e);

            // 到此，异步调用以及事件的响应全部处理结束。
            _isBusy = false;
        } 

    }
}
