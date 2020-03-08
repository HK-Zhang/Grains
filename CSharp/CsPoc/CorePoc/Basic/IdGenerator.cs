using System;
using System.Collections.Generic;
using System.Text;

namespace CorePoc.Basic
{
    public static class IdGenerator
    {
        private static string _codeset = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static DateTime _datebase = new DateTime(2019, 12, 1, 1, 1, 1);

        public static void Execute()
        {
            GenerateId();
        }

        private static void GenerateId()
        {
            var tickSpan = DateTime.UtcNow.Ticks - _datebase.Ticks;

            var a = new DateTime(2050, 1, 1, 1, 1, 1);


            Console.WriteLine(tickSpan);
            Console.WriteLine((a-_datebase).TotalMilliseconds);
            Console.WriteLine((long)62 * 62 * 62 * 62 * 62 * 62);
            Console.WriteLine((a - _datebase).Ticks > (long)62 * 62 * 62 * 62 * 62 * 62 * 62 * 62 * 62);


            Random rnd = new Random();

            var codeRight = rnd.Next(0, 61);

            Console.WriteLine(Math.Pow(3, 2));

            var span = ((DateTime.UtcNow - _datebase).TotalMilliseconds);

            Console.WriteLine($"{_codeset[Get(span, 6)]}{_codeset[Get(span, 5)]}{_codeset[Get(span, 4)]}{_codeset[Get(span, 3)]}{_codeset[Get(span, 2)]}{_codeset[Get(span, 1)]}{_codeset[codeRight]}");

            Console.WriteLine((a - _datebase).TotalSeconds > (long)62 * 62 * 62 * 62 * 62);
        }

        private static int Get(double x, int y)
        {
            var a = x / Math.Pow(62, y);
            if (a < 62) return (int)a;

            var b = x % Math.Pow(62, y);

            if (b >= 62)
            {
                return Get(b, y - 1);
            }
            else
            {
                return (int)b;
            }

        }
    }
}
