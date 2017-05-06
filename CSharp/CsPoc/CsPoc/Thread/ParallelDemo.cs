using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc
{
    class ParallelDemo
    {

        public static void RunDemo() 
        {
            //Parallel.Invoke(Credit,Email);

            //List<Action> lst = new List<Action>() { Credit, Email };
            //var result= Parallel.For(0, lst.Count, (i) => { lst[i](); });
            //Foo1();

            int maxThreadNum, portThreadNum;

            int minThreadNum;

            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);

            ThreadPool.SetMinThreads(10, portThreadNum);
            //ThreadPool.SetMaxThreads(250, portThreadNum);

            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);

 

            Console.WriteLine("max thead number in thread pool：{0}", maxThreadNum);

            Console.WriteLine("min idle thead number in thread pool：{0}", minThreadNum);

            //Foo3();
            //Foo4();
            Foo2();

        }

        static void Foo2()
        {
            int a = 0;
            System.Threading.Tasks.Parallel.For(0, 100000, new ParallelOptions { MaxDegreeOfParallelism = 100 }, (i) =>
            {
                a++;
                //while (true)
                //{

                //}
            });
            Console.Write(a);
        }

        static void Foo3()
        {
            int a = 0;
            var w = new ManualResetEvent(false);
            System.Threading.Tasks.Parallel.For(0, 101, (i) =>
            {

                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                if (i < 100)
                {
                    w.WaitOne();
                }
                else
                {
                    w.Set();
                }

                Console.WriteLine(i);
                ++a;
            });
            
            Console.Write(a);
        }

        static void Foo4()
        {
            int a = 0;
            Random r = new Random();
            System.Threading.Tasks.Parallel.For(0, 1000, (i) =>
            {
                Thread.Sleep(r.Next(1000/10));
                Console.WriteLine(i);
                ++a;
            });

            Console.Write(a);
        }

        static void Foo1()
        {
                        var list = new List<int>() {10,20,30,40,50 };
            var options = new ParallelOptions();
            var total = 0;
            var result = Parallel.For(0, list.Count,
                () =>
                {
                    Console.WriteLine("Thread");
                    return 1;
                },
                (i, loop, j) =>
                {
                    Console.WriteLine("body");
                    Console.WriteLine("i= " + list[i] + " j=" + j);
                    return list[i];
                },
                (i) => 
                {
                    Console.WriteLine("Foot");
                    Interlocked.Add(ref total,i);
                    Console.WriteLine("total="+total);
                });


            Console.WriteLine(result.IsCompleted);
        }

        static void Credit()
        {
            Console.WriteLine("Credit is doing");
            Thread.Sleep(3000);
            Console.WriteLine("Credit is done");
        }

        static void Email()
        {
            Console.WriteLine("Email is sending");
            Thread.Sleep(2000);
            Console.WriteLine("Email is done");
        }
    }
}
