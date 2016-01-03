using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class PerformanceTest
    {
        public static void Execute()
        {
            int start = Environment.TickCount;

            for (int i = 0; i < 1000; i++)
            {

                string s = "";

                for (int j = 0; j < 200; j++)
                {

                    s += "Outer index = ";

                    s += i;

                    s += " Inner index = ";

                    s += j;

                    s += " ";

                }

            }

            int middle = Environment.TickCount;

            Console.WriteLine("Program part1 run for {0} seconds", 0.001 * (middle - start));

            //

            for (int i = 0; i < 1000; i++)
            {

                StringBuilder s = new StringBuilder();

                for (int j = 0; j < 200; j++)
                {

                    s.Append("Outer index = ");

                    s.Append(i);

                    s.Append("Inner index = ");

                    s.Append(j);

                    s.Append(" ");

                }

            }

            int end = Environment.TickCount;

            Console.WriteLine("Program part2 run for {0} seconds", 0.001 * (end - middle));



            //

            Console.ReadKey();

        }
    }
}
