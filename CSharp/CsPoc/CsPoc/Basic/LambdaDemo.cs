using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    delegate void TestDelegate(string s);
    class LambdaDemo
    {
        static void Dowork(string s)
        {
            Console.WriteLine(s);
        }

        public static void Execute() {
            TestDelegate d1 = new TestDelegate(Dowork);
            TestDelegate d2 = delegate(string s) { Console.WriteLine(s); };
            TestDelegate d3 = (x) => { Console.WriteLine(x); };
            d1("Hello World");
            d2("Hello World2");
            d3("Hello World3");
            TestLambda((x) => { Console.WriteLine(x); });
        }

        public static void TestLambda(TestDelegate ti) 
        {
            ti("Hello World4");
        }
    }


}
