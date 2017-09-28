using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemo
{
    public class TimerDemo
    {
        public static void Execute()
        {
            TimespanDemo();
        }

        private static void foo1()
        {
            TimerObject s = new TimerObject();
            TimerCallback timerdelegate = new TimerCallback(CheckStatus);
            Timer timer = new Timer(timerdelegate, s, 2000, 1000);

            while (s.Counter < 10)
            {
                Thread.Sleep(1);
            }

            timer.Change(1000, 500);
            Console.WriteLine("Timer speed up！");

            while (s.Counter < 20)
            {
                Thread.Sleep(1);
            }

            timer.Dispose();
            Console.WriteLine("Timer over！");
            Console.ReadLine();
        }


        public static void TimespanDemo()
        {
            var a = new TimeSpan(0, 1, 30);
            var b = 200 / 9;
        }



        static void CheckStatus(object state)
        {
            TimerObject s = (TimerObject)state;
            s.Counter++;
            Console.WriteLine("current time：{0} timer count：{1}", DateTime.Now.ToString(), s.Counter);

        }
    }

    class TimerObject
    {
        public int Counter = 0;
    }
}
