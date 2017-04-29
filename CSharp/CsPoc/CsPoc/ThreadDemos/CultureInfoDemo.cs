using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc.ThreadNS
{
    public class CultureInfoDemo
    {

        static readonly string[] CultureSources = { "en-us", "zh-cn", "ar-iq", "de-de" };

        static readonly Random Ran = new Random(Environment.TickCount);

        public void Execute()
        {
            Foo();
            //Foo1();
        }

        private void Foo()
        {
            Console.WriteLine("数据中心开始接受客户端数据：");

            for (int i = 0; i < CultureSources.Length; i++)
                ThreadPool.QueueUserWorkItem(Client, i);

            Console.WriteLine("");

            Console.WriteLine("数据中心：…………");
        }

        static void Client(object obj)
        {

            int id = (int)obj;

            Thread.Sleep(Ran.Next(1000));



            CultureInfo cul = CultureInfo.GetCultureInfo(CultureSources[id]);

            Thread.CurrentThread.CurrentCulture = cul;

            Console.WriteLine("某客户端操作系统语言设置{0}\n传送数据：{1}\n", cul.DisplayName, new DateTime(1990, 10, 27).ToShortDateString());
            Console.WriteLine("某客户端操作系统语言设置{0}\n传送数据：{1}\n", cul.DisplayName,new DateTime(1990, 10, 27).ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture));
            Sanitize();
            Console.WriteLine("某客户端操作系统语言设置{0}\n传送数据：{1}\n", cul.DisplayName, new DateTime(1990, 10, 27).ToShortDateString());
        }

        public static void Sanitize()
        {
            var currentCulture = CultureInfo.CurrentCulture;

            // at the top of any culture should be the invariant culture,
            // find it doing an .Equals comparison ensure that we will
            // find it and not loop endlessly
            var invariantCulture = currentCulture;
            while (invariantCulture.Equals(CultureInfo.InvariantCulture) == false)
            {
                invariantCulture = invariantCulture.Parent;
            }

            if (ReferenceEquals(invariantCulture, CultureInfo.InvariantCulture))
            {
                return;
            }

            var thread = Thread.CurrentThread;
            thread.CurrentCulture = CultureInfo.GetCultureInfo(thread.CurrentCulture.Name);
            //thread.CurrentUICulture = CultureInfo.GetCultureInfo(thread.CurrentUICulture.Name);
        }

        private void Foo1()
        {
            string[] strs = { "a", "A", "b", "B", "abc", "ab", "aB", "AB", "Ab", "aaa" };

            Console.WriteLine("en-US");

            Array.Sort<string>(strs, StringComparer.Create(CultureInfo.GetCultureInfo("en-us"), false));

            Console.WriteLine(String.Join(" < ", strs));



            Console.WriteLine("zh-CN");

            Array.Sort<string>(strs, StringComparer.Create(CultureInfo.GetCultureInfo("zh-CN"), false));

            Console.WriteLine(String.Join(" < ", strs));



            Console.WriteLine("Ordinal");

            Array.Sort<string>(strs, StringComparer.Ordinal);

            Console.WriteLine(String.Join(" < ", strs));



            Console.WriteLine("Invariant");

            Array.Sort<string>(strs, StringComparer.InvariantCulture);

            Console.WriteLine(String.Join(" < ", strs));
        }
    }
}
