using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class StringFormatDemo
    {
        public static void Foo()
        {
            int x = 16;
            decimal y = 3.57m;
            Console.WriteLine("item {0} sells at {1:C}", x, y);

            Console.WriteLine("{0,5} {1,5}", 123, 456);      // 右对齐
            Console.WriteLine("{0,-5} {1,-5}", 1234, 456);    // 左对齐

            Console.WriteLine("\n{0,-10}{1,-3}", "Name", "Salary");
            Console.WriteLine("----------------");
            Console.WriteLine("{0,-10}{1,6}", "Bill", 123456);
            Console.WriteLine("{0,-10}{1,6}", "Polly", 7890);

            int i = 123456;
            Console.WriteLine("{0:C}", i); // ￥123,456.00
            Console.WriteLine("{0:D}", i); // 123456
            Console.WriteLine("{0:E}", i); // 1.234560E+005
            Console.WriteLine("{0:F}", i); // 123456.00
            Console.WriteLine("{0:G}", i); // 123456
            Console.WriteLine("{0:N}", i); // 123,456.00
            Console.WriteLine("{0:P}", i); // 12,345,600.00 %
            Console.WriteLine("{0:X}", i); // 1E240

            Console.WriteLine("{0:C5}", i); // ￥123,456.00
            Console.WriteLine("{0:D5}", i); // 123456
            Console.WriteLine("{0:E5}", i); // 1.23456E+005
            Console.WriteLine("{0:F5}", i); // 123456.00000
            Console.WriteLine("{0:G5}", i); // 1.23456E5
            Console.WriteLine("{0:N5}", i); // 123,456.00000
            Console.WriteLine("{0:P5}", i); // 12,345,600.00000 %
            Console.WriteLine("{0:X5}", i); // 1E240

            double j = 123456.42;
            Console.WriteLine();
            Console.WriteLine("{0:000000.00}", j); //123456.42
            Console.WriteLine("{0:00.00000000e+0}", j); //12.34564200e+4
            Console.WriteLine("{0:0,.}", j);          //123
            Console.WriteLine("{0:#0.000}", j);             // 123456.420
            Console.WriteLine("{0:#0.000;(#0.000)}", j);        // 123456.420
            Console.WriteLine("{0:#0.000;(#0.000);<zero>}", j); // 123456.420
            Console.WriteLine("{0:#%}", j);     // 12345642%

            j = -123456.42;
            Console.WriteLine();
            Console.WriteLine("{0:000000.00}", j); //-123456.42
            Console.WriteLine("{0:00.00000000e+0}", j); //-12.34564200e+4
            Console.WriteLine("{0:0,.}", j);          //-123
            Console.WriteLine("{0:#0.000}", j);             // -123456.420
            Console.WriteLine("{0:#0.000;(#0.000)}", j);        // (123456.420)
            Console.WriteLine("{0:#0;(#0);<zero>}", j); // (123456)
            Console.WriteLine("{0:#%}", j);             // -12345642%

            j = 0;
            Console.WriteLine();
            Console.WriteLine("{0:0,.}", j);          //0
            Console.WriteLine("{0:#0}", j);             // 0
            Console.WriteLine("{0:#0;(#0)}", j);        // 0
            Console.WriteLine("{0:#0;(#0);<zero>}", j); // <zero>
            Console.WriteLine("{0:#%}", j);             // %
        }

        public static void Foop() {
            string t = "  -1,234,567.890  ";
            double g = double.Parse(t);
            Console.WriteLine("g = {0:F}", g);

            string u = "￥  -1,234,567.890  ";
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencySymbol = "￥";
            double h = Double.Parse(u, NumberStyles.Any, ni);
            Console.WriteLine("h = {0:F}", h);

            int k = 12345;
            CultureInfo us = new CultureInfo("en-US");
            string v = k.ToString("c", us);
            Console.WriteLine(v);
        }

        public static void Food()
        {
            DateTime dt = DateTime.Now;
    
            DateTimeFormatInfo dtfi = DateTimeFormatInfo.InvariantInfo;
            Console.WriteLine(dt.ToString("D", dtfi));
            Console.WriteLine(dt.ToString("f", dtfi));
            Console.WriteLine(dt.ToString("F", dtfi));
            Console.WriteLine(dt.ToString("g", dtfi));
            Console.WriteLine(dt.ToString("G", dtfi));
            Console.WriteLine(dt.ToString("m", dtfi));
            Console.WriteLine(dt.ToString("r", dtfi));
            Console.WriteLine(dt.ToString("s", dtfi));
            Console.WriteLine(dt.ToString("t", dtfi));
            Console.WriteLine(dt.ToString("T", dtfi));
            Console.WriteLine(dt.ToString("u", dtfi));
            Console.WriteLine(dt.ToString("U", dtfi));
            Console.WriteLine(dt.ToString("d", dtfi));
            Console.WriteLine(dt.ToString("y", dtfi));
            Console.WriteLine(dt.ToString("dd-MMM-yy", dtfi));

            dtfi = DateTimeFormatInfo.CurrentInfo;
            Console.WriteLine(dt.ToString("D", dtfi));
            Console.WriteLine(dt.ToString("f", dtfi));
            Console.WriteLine(dt.ToString("F", dtfi));
            Console.WriteLine(dt.ToString("g", dtfi));
            Console.WriteLine(dt.ToString("G", dtfi));
            Console.WriteLine(dt.ToString("m", dtfi));
            Console.WriteLine(dt.ToString("r", dtfi));
            Console.WriteLine(dt.ToString("s", dtfi));
            Console.WriteLine(dt.ToString("t", dtfi));
            Console.WriteLine(dt.ToString("T", dtfi));
            Console.WriteLine(dt.ToString("u", dtfi));
            Console.WriteLine(dt.ToString("U", dtfi));
            Console.WriteLine(dt.ToString("d", dtfi));
            Console.WriteLine(dt.ToString("y", dtfi));
            Console.WriteLine(dt.ToString("dd-MMM-yy", dtfi));
        }
    }
}
