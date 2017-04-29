using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CsPoc.ThreadNS
{
    public class TaskCompletionSourceDemo
    {
        public void Execute()
        {
            //RunAsThread();
            //Foo();
            //Foo2();
            //Foo3();
            Foo4();
        }

        private void RunAsThread()
        {
            var tcs = new TaskCompletionSource<int>();
            new Thread(() => {
                Thread.Sleep(5000);
                int i = Enumerable.Range(1, 100).Sum();
                tcs.SetResult(i); 
            }).Start();
            Console.WriteLine("Thread start");
            Task<int> task = tcs.Task;
            Console.WriteLine(task.Result); 

        }

        private void Foo()
        {
            
            Task<int> task = Run(() => { Thread.Sleep(5000); return Enumerable.Range(1, 100).Sum(); });
            Console.WriteLine("Task start");
            Console.WriteLine(task.Result);
        }

        private void Foo2()
        {
            var task = DelayFunc();
            Console.WriteLine("Task start");
            Console.WriteLine("P:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(task.Result);
        }

        private void Foo3()
        {
            var s= Task.FromResult("abc");
            Console.WriteLine(s.Result);
        }

        Task<TResult> Run<TResult>(Func<TResult> function) {
            var tcs = new TaskCompletionSource<TResult>();
            Thread t = new Thread(() => {
                try
                {
                    tcs.SetResult(function());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            t.IsBackground = true;
            t.Start();
            return tcs.Task;
        }

        static Task<int> DelayFunc()
        {
            var tcs = new TaskCompletionSource<int>();
            var timer = new System.Timers.Timer(5000) { AutoReset = false };
            timer.Elapsed += (sender, e) => {
                timer.Dispose();
                int i = Enumerable.Range(1, 100).Sum();
    
                tcs.SetResult(i);
                Console.WriteLine("C:"+Thread.CurrentThread.ManagedThreadId);
            };

            timer.Start();
            return tcs.Task;
        }

        private void Foo4()
        {
            var task = ApiWrapper();
            Console.WriteLine("Foo4:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(task.Result);
        }

        static Task<string> ApiWrapper()
        {
            var tcs = new TaskCompletionSource<string>();

            var api = new EventClass();

            api.Done += (args) => { tcs.SetResult(args); };

            api.Do();

            return tcs.Task;
        }
    }

    public class EventClass
    {
        public Action<string> Done =(args)=>{;};

        public void Do()
        {
            Console.WriteLine("EventClass:" + Thread.CurrentThread.ManagedThreadId);
            Done("Done");
        }
        
    }

    
}
