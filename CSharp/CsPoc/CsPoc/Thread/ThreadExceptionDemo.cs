using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc
{
    public class ThreadExceptionDemo
    {
        public int x = 0;

        public void Execute()
        {
            Foo1();
            Thread.Sleep(1000);
            Foo1();
            Thread.Sleep(4000);
            Foo1();
        }

        private void Foo1()
        {
            Console.WriteLine(x);

            Task.Run(() =>
            {
                try
                {
                    x = 1;
                    Thread.Sleep(1000);
                    throw new Exception();
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    x = 0;
                }
            });



        }
    }
}
