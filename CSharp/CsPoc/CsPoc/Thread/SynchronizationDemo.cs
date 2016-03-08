using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc
{
    class SynchronizationDemo
    {
        private string _s = "";
        private AsyncOperation operation;
        public event EventHandler somethingHappened;

        public void Run()
        {
            Output("Main Thread Start.");

            var context = new SynchronizationContext();
            Thread threadB = new Thread(work);
            threadB.Start(context);
            _s = "are you sure";
        }

        void Output(object value)
        {
            Console.WriteLine("[ThreadID:#{0}]{1},{2}", Thread.CurrentThread.ManagedThreadId, value,_s);
        }

        void work(object context)
        {
            _s = "sure";
            Output("Thread B");
            SynchronizationContext sc = context as SynchronizationContext;
            sc.Post(new SendOrPostCallback(p =>
            {
                Output(p);
            }), "Hello World");

            //sc.Send(new SendOrPostCallback(p =>
            //{
            //    Output(p);
            //}), "Hello World");


        }

        public void Run2()
        {
            somethingHappened += SynchronizationDemo_somethingHappened;
            operation = AsyncOperationManager.CreateOperation(null);
            Thread workerThread = new Thread(new ThreadStart(DoWork));
            workerThread.Start();
            Thread.Sleep(2000);
            Output("Call end");
        }

        void SynchronizationDemo_somethingHappened(object sender, EventArgs e)
        {
            Output("Call Back");
        }
        private void DoWork()
        {
            SendOrPostCallback callback = new SendOrPostCallback(state =>
            {
                EventHandler handler = somethingHappened;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            });

            operation.Post(callback, null);
            operation.OperationCompleted();


        }

    }
}
