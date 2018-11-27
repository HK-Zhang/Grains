using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Itenso.TimePeriod;

namespace CSDemo
{
    public class TimerDemo
    {
        public static void Execute()
        {
            //TimespanDemo();
            //DayOfWeek();
            //            DateParse();
//            TimeblockFun();
//            GetFirstDayOfWeekFun();

//            var n = DateTime.Now;
//            var n2 = DateTime.Now.AddHours(1);
//            Console.WriteLine(TimeDifference(n, n2));

            var r = new DateTime(2018, 12, 1, 1, 1, 16);
            Console.WriteLine(RoundTime(r, 30));
            Console.WriteLine(RoundTime(new DateTime(2018, 12, 1, 1, 1, 15), 30));
            Console.WriteLine(RoundTime(new DateTime(2018, 12, 1, 1, 1, 14), 30));
            Console.WriteLine(RoundTime(new DateTime(2018, 12, 1, 1, 1, 44), 30));
            Console.WriteLine(RoundTime(new DateTime(2018, 12, 1, 1, 1, 45), 30));
            Console.WriteLine(RoundTime(new DateTime(2018, 12, 1, 1, 1, 46), 30));


        }


        public static void TimeblockFun()
        {
            var a = new TimeBlock(new DateTime(2010, 12, 1), new DateTime(2010, 12, 2));

            var v = new DateTime(2010, 12, 2);
            v = new DateTime(v.Ticks - 1);
            var b = new TimeBlock(v, new DateTime(2010, 12, 2));

            Console.WriteLine(a.OverlapsWith(b));

        }

        private static void DateParse()
        {
            var d = DateTime.Parse("2017-12-10T00:00:00Z");
            var e = DateTime.Parse("2017-12-10T00:00:00.000+01:00");

            Console.WriteLine(d.Day);
            Console.WriteLine(e.Day);
        }

        private static void DayOfWeek()
        {
            Console.WriteLine(DateTime.Now.Day);
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

        public static DateTime RoundTime(DateTime date, int nearestSeconds)
        {
            TimeSpan span = new TimeSpan(0, 0, nearestSeconds);
            long ticks = (date.Ticks + (span.Ticks / 2) + 1) / span.Ticks;
            return new DateTime(ticks * span.Ticks);
        }

        public static int TimeDifference(DateTime date1, DateTime date2)
        {
            return Math.Abs(Convert.ToInt32((date1 - date2).TotalSeconds));
        }

        static void CheckStatus(object state)
        {
            TimerObject s = (TimerObject)state;
            s.Counter++;
            Console.WriteLine("current time：{0} timer count：{1}", DateTime.Now.ToString(), s.Counter);

        }

        public static void GetFirstDayOfWeekFun()
        {
            int i = 1;

            while (i<15)
            {
                Console.WriteLine(GetFirstDayOfWeek(2018, i));

                i++;
            }
        }

        public static DateTime GetFirstDayOfWeek(int year, int week)
        {
            var jan1 = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var daysOffset = System.DayOfWeek.Thursday - jan1.DayOfWeek;
            var firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            var firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, System.DayOfWeek.Monday);
            var weekNum = week;
            if (firstWeek <= 1) weekNum -= 1;
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }
    }

    class TimerObject
    {
        public int Counter = 0;
    }
}
