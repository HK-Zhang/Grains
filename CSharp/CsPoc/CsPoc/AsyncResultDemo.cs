using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemo
{
    class AsyncResultDemo
    {
        private static object _synLock = new object();

        private void Await(Action action)
        {
            lock (_synLock)
            {
                Console.WriteLine("get lock");
            }

            action();
        }

        private IAsyncResult BeginOperation(AsyncCallback cb, object extradata)
        {
            var asyncResult = new DemoAsyncResult(cb, extradata);
            Console.WriteLine("Begin Operation Step1");
            Await(asyncResult.Completed);
            Console.WriteLine("Begin Operation Step2");
            return asyncResult;
        }

        private static void EndOperation(IAsyncResult ar)
        {
            Console.WriteLine("End Operation");
        }

        static void outPut(IAsyncResult ar)
        {
            EndOperation(ar);
            Console.WriteLine("Call back");
        }  

        public void Run()
        {
            Task.Run(new Action(lockForTest));
            BeginOperation(new AsyncCallback(outPut), null);
            Console.WriteLine("Complete call BeginOperation");
        }

        private void lockForTest() 
        {
            lock (_synLock)
            {
                Thread.Sleep(3000);
            }
        }
    }

    class DemoAsyncResult : IAsyncResult
    {
        private readonly EventWaitHandle _eventWaitHandle = new AutoResetEvent(false/*initialState*/);
        private readonly AsyncCallback _cb;
        private readonly object _asyncState;
        private bool _isCompleted;

        public DemoAsyncResult(AsyncCallback cb, object asyncState)
        {
            _cb = cb;
            _asyncState = asyncState;
            _isCompleted = false;
        }

        public void Completed()
        {
            _isCompleted = true;
            _eventWaitHandle.Set();
            _cb(this);
        }

        bool IAsyncResult.CompletedSynchronously
        {
            get { return false; }
        }

        bool IAsyncResult.IsCompleted
        {
            get { return _isCompleted; }
        }

        object IAsyncResult.AsyncState
        {
            get { return _asyncState; }
        }

        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return _eventWaitHandle; }
        }
    }
}
