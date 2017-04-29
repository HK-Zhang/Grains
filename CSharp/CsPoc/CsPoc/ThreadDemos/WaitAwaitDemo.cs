using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc.ThreadTest
{
    public class WaitAwaitDemo
    {
        public static void Execute()
        {
            //Foo2();
            Foo1();
        }

        private static void Foo1()
        {
            Console.WriteLine("Program Begin");
            // DoAsTask();
            DoAsAsync();
            Console.WriteLine("Program End");

        }

        private static void Foo2()
        {
            Console.WriteLine("Program Begin");
            DoAsTask();
            //DoAsAsync();
            Console.WriteLine("Program End");
        }

        static void DoAsTask()
        {
            Console.WriteLine("1 - Starting");
            var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
            Console.WriteLine("2 - Task started");
            t.Wait();
            Console.WriteLine("3 - Task completed with result: " + t.Result);
        }

        static async void DoAsAsync()
        {
            Console.WriteLine("1 - Starting");
            var t = Task.Factory.StartNew<int>(DoSomethingThatTakesTime);
            Console.WriteLine("2 - Task started");
            var result = await t;
            Console.WriteLine("3 - Task completed with result: " + result);
        }

        static int DoSomethingThatTakesTime()
        {
            Console.WriteLine("A - Started something");
            Thread.Sleep(1000);
            Console.WriteLine("B - Completed something");
            return 123;
        }
    }
}
