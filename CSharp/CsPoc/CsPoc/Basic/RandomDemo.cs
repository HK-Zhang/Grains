using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    public class RandomDemo
    {
        public void Execute()
        {
            Random rnd = new Random();

            for (int i = 0; i < 1; i++)
            {
                var s = "\"P_MODE\":\"SUBMIT\"";
                Console.WriteLine(s);
                Console.WriteLine(s.Contains("\"SUBMIT\""));
                Console.WriteLine(rnd.Next(2, 7).ToString());
            }
        }
    }
}
