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
