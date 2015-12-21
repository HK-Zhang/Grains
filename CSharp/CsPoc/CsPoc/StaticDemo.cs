using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class StaticDemoA
    {
        public static int X = StaticDemoB.Y;

        static StaticDemoA() 
        {
            ++X;
            Console.WriteLine("X:" + X.ToString());
        }
    }

    class StaticDemo 
    {
       public static void Execute()
        {
            Console.WriteLine(StaticDemoA.X.ToString());
            Console.WriteLine(StaticDemoB.Y.ToString());
        }
    }


    class StaticDemoB
    {
        public static int Y = StaticDemoA.X;

        static StaticDemoB() 
        {
            ++Y;
            Console.WriteLine("Y:"+Y.ToString());
        }
    }
    
    class StaticDemoC
    {
        static int i = 1;

        static StaticDemoC() 
        {
            Console.WriteLine(i);
            Console.WriteLine(j);
        }

        public static void Execute()
        {
        }

        static int j = 1;
    }
}
