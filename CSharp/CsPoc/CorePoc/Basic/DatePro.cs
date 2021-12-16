using System;
using System.Collections.Generic;
using System.Text;

namespace CorePoc.Basic
{
    public class DatePro
    {
        public static void Execute()
        {
            DateTime dateValue = new DateTime(2008, 6, 1, 21, 15, 07);
            Console.WriteLine(dateValue.ToString("yyyy-M-d"));
        }
    }
}
