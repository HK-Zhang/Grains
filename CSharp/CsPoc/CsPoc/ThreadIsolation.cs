using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemo
{
    public class ThreadIsolation
    {
        static int si = 0;
        static IntWrapper iw = new IntWrapper();
        

        public static void RunTest()
        {
            Object lockObj = new Object();

            Console.WriteLine(iw.i);

            Task.Run(() => {
                lock (lockObj)
                {
                    iw.i = 1;
                    Thread.Sleep(5000); 
                }

            });

            Console.WriteLine(iw.i);

            Thread.Sleep(1000);

            Console.WriteLine(iw.i);
        }
    }

    public class IntWrapper
    {
        public int i = 0;
    }
}
