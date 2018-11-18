using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc
{
    class ThreadDemo
    {
        AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        //AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
        ManualResetEvent _manualResetEvent = new ManualResetEvent(false);

        void Thread1Foo()
        {
            _autoResetEvent.WaitOne();
            Console.WriteLine("T1 end");
        }

        void Thread2Foo()
        {
            _autoResetEvent.WaitOne();
            Console.WriteLine("T2 end");
        }


        void Thread3Foo()
        {
            _manualResetEvent.WaitOne();
            Console.WriteLine("T3 end");
        }

        void Thread4Foo()
        {
            _manualResetEvent.WaitOne();
            Console.WriteLine("T4 end");
        }

        void Thread5Foo()
        {
            _manualResetEvent.WaitOne();
            Console.WriteLine("T5 step1 end");
            Thread.Sleep(1000);
            _manualResetEvent.WaitOne();
            Console.WriteLine("T5 step2 end");
        }

        void Thread6Foo()
        {
            _manualResetEvent.WaitOne();
            Console.WriteLine("T6 step1 end");
            Thread.Sleep(1000);
            _manualResetEvent.WaitOne();
            Console.WriteLine("T6 step2 end");
        }

        public void Test1Foo()
        {
            Thread t1 = new Thread(Thread1Foo);
            t1.Start();
            Thread.Sleep(1000);
            _autoResetEvent.Set();
        }


        public void Test2Foo()
        {
            Task.Run(new Action(Thread1Foo));
            Task.Run(new Action(Thread2Foo));
            Thread.Sleep(3000);
            _autoResetEvent.Set();

        }

        public void Test3Foo()
        {
            Task.Factory.StartNew(Thread3Foo);
            Task.Factory.StartNew(Thread4Foo);
            Thread.Sleep(1000);
            _manualResetEvent.Set();
        }

        public void Test4Foo()
        {
            Task.Factory.StartNew(Thread5Foo);
            Task.Factory.StartNew(Thread6Foo);
            Thread.Sleep(1000);
            _manualResetEvent.Set();
            //_manualResetEvent.Reset();
        }

        public void Test5Foo()
        {
            Thread thread = new Thread(new ThreadStart(delegate ()
                {
                    Thread.Sleep(2000);
                    _autoResetEvent.Set();
                    _manualResetEvent.Set();
                }
                ));

            thread.Start();

            WaitHandle[] wait = new WaitHandle[2];
            wait[0] = _autoResetEvent;
            wait[1] = _manualResetEvent;

            Thread.Sleep(1000);

            int b = WaitHandle.WaitAny(wait);
            Console.WriteLine("Test 5 Foo");

        }

        public void Test6Foo()
        {
            // AutoResetEvent autoEvent = new AutoResetEvent(false);
            Thread regularThread = new Thread(new ThreadStart(ThreadMethod));
            regularThread.Start();
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorkMethod1), regularThread);

            Console.WriteLine("i am main thread!");
            //   regularThread.Join();
            Console.WriteLine("i am main thread!");
            //   autoEvent.WaitOne();
            Console.Read();
        }

        public void CancelTask()
        {
            using (var cts = new CancellationTokenSource())
            {
                Task t = new Task(() => LongRunTask(cts.Token));
                t.Start();
                Thread.Sleep(2000);
                cts.Cancel();
            }

        }

        public void CancelTasks()
        {
            Task parent = new Task(() =>
            {
                using (var cts = new CancellationTokenSource())
                {
                    TaskFactory tf = new TaskFactory(cts.Token);
                    var childTask = new[] { tf.StartNew(() => LongRunTask(cts.Token)), tf.StartNew(() => LongRunTask(cts.Token)), tf.StartNew(() => LongRunTask(cts.Token)) };
                    Thread.Sleep(2000);
                    cts.Cancel();
                }
            });

            parent.Start();
        }

        private void LongRunTask(CancellationToken cts)
        {
            for (int i = 0; i < 100; i++)
            {
                if (!cts.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
                else
                {
                    Console.WriteLine("Thread is abort");
                    break;
                }

            }
        }

        static void ThreadMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ThreadOne 第 {0} 次执行,executing ThreadMethod,is {1} from the thread pool.", i + 1, Thread.CurrentThread.IsThreadPoolThread ? "" : "not");
                Thread.Sleep(1000);
            }


        }
        static void WorkMethod1(object stateInfo)
        {
            Console.WriteLine("ThreadTwo,executing WorkMethod,is {0} form the thread pool.", Thread.CurrentThread.IsThreadPoolThread ? "" : "not");
            // ((AutoResetEvent)stateInfo).Set();
            ((Thread)stateInfo).Join();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ThreadTwo 第 {0}次执行,executing WorkMethod,is {1} form the thread pool.", i + 1, Thread.CurrentThread.IsThreadPoolThread ? "" : "not");
            }


        }
    }




    public class AsyncDemo
    {
        // Use in asynchronous methods  
        private delegate string runDelegate();
        private string m_Name;
        private runDelegate m_Delegate;

        public AsyncDemo(string name)
        {
            m_Name = name;
            m_Delegate = new runDelegate(Run);
        }


        public string Run()
        {
            return "My name is " + m_Name;
        }


        public IAsyncResult BeginRun(AsyncCallback callBack, Object stateObject)
        {
            try
            {
                return m_Delegate.BeginInvoke(callBack, stateObject);
            }
            catch (Exception e)
            {
                // Hide inside method invoking stack  
                throw e;
            }

        }

        public string EndRun(IAsyncResult ar)
        {
            if (ar == null)
                throw new NullReferenceException("Arggument ar can't be null");

            try
            {
                return m_Delegate.EndInvoke(ar);
            }

            catch (Exception e)
            {
                // Hide inside method invoking stack  
                throw e;

            }

        }

    }


    class AsyncTest
    {

        static AsyncDemo demo2 = new AsyncDemo("jiangnii");
        public static void Run()
        {
            AsyncDemo demo = new AsyncDemo("jiangnii");

            // Execute begin method  
            IAsyncResult ar = demo.BeginRun(null, null);

            // You can do other things here  
            // Use AsyncWaitHandle.WaitOne method to block thread for 1 second at most  
            ar.AsyncWaitHandle.WaitOne(1000, false);

            if (ar.IsCompleted)
            {
                // Still need use end method to get result,  
                // but this time it will return immediately   
                string demoName = demo.EndRun(ar);
                Console.WriteLine(demoName);
            }
            else
            {
                Console.WriteLine("Sorry,  can't get demoName, the time is over");
            }

        }

        public static void Run2()
        {

            AsyncDemo demo = new AsyncDemo("jiangnii");

            // Execute begin method  
            IAsyncResult ar = demo.BeginRun(null, null);

            Console.Write("Waiting..");
            while (!ar.IsCompleted)
            {
                Console.Write(".");
                // You can do other things here  
            }

            Console.WriteLine();

            // Still need use end method to get result,   
            //but this time it will return immediately   
            string demoName = demo.EndRun(ar);
            Console.WriteLine(demoName);

        }

        public static void Run3()
        {
            // State object  
            bool state = false;

            // Execute begin method  
            IAsyncResult ar = demo2.BeginRun(new AsyncCallback(outPut), state);

            // You can do other thins here  
            // Wait until callback finished  
            System.Threading.Thread.Sleep(1000);
        }

        // Callback method  

        static void outPut(IAsyncResult ar)
        {
            bool state = (bool)ar.AsyncState;
            string demoName = demo2.EndRun(ar);

            if (state)
            {
                Console.WriteLine(demoName);
            }
            else
            {
                Console.WriteLine(demoName + ", isn't it?");
            }

        }

    }

}
