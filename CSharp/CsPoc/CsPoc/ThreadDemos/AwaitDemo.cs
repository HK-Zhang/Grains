using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc
{
    public class AwaitDemo
    {
        public void  Execute()
        {
            //Foo1();
            Foo2();
        }

        private void Foo1()
        {
            Console.WriteLine("Start Foo1");
            ProcessAsync2("ABC");
            Console.WriteLine("End Foo1");
        }

        private void Foo2()
        {

            if (CallContext.GetData("test") == null)
            {
                CallContext.SetData("test", "M1");
            }


            Console.WriteLine("Start Foo1");
            string s = ProcessAsync2("ABC").Result;
            Console.WriteLine("End Foo1");
        }

        private Task<string> DoSomethingAsync(string value)
        {
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                return value.ToLower();
            });
        }

        private Task<string> DoSomethingAsync2(string value)
        {
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                return value.ToUpper();
            });
        }
        private async Task<string> ProcessAsync2(string value)
        {
            Console.WriteLine("r1 s");
            if (CallContext.GetData("test") == null) 
            {
                CallContext.SetData("test", "M1");
            }

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.GetData("test"));

            var r1 = await DoSomethingAsync(value);
            Console.WriteLine("r1 e r2 s");
            if (CallContext.GetData("test") == null)
            {
                CallContext.SetData("test", "M2");
            }

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.GetData("test"));
            var r2 = await DoSomethingAsync2(r1);
            Console.WriteLine("r2 e");
            if (CallContext.GetData("test") == null)
            {
                CallContext.SetData("test", "M3");
            }

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.GetData("test"));

            return r2;
        }
    }


}
