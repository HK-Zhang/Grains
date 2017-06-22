using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Advanced
{
    public class MiddleDesign
    {
        //public delegate string RequestDelegate(string context);
        public void Execute()
        {
            Func<string, string> requestOne = (string a) => a + " One";
            Func<string, string> requestTwo = (string a) => a + " Two";
            Func<string, string> requestThree = (string a) => a + " Three";

            List<Func<Func<string, string>, Func<string, string>>> middles =
                new List<Func<Func<string, string>, Func<string, string>>>();

            middles.Add(Process());
            middles.Add(ProcessTwo());

            middles.ForEach(t => requestOne = t(requestOne));

            Console.WriteLine(requestOne("Hello World"));
        }

        public Func<Func<string, string>, Func<string, string>> Process()
        {
            Func<string, string> Middleware(Func<string, string> next)
            {
                string Func(string context)
                {
                    /*process request*/
                    Console.WriteLine("begin process");
                    context = next(context);

                    /*process response*/
                    Console.WriteLine("end process");
                    return context;
                }

                return Func;
            }

            return Middleware;
        }

        public Func<Func<string, string>, Func<string, string>> ProcessTwo()
        {
            Func<string, string> Middleware(Func<string, string> next)
            {
                string Func(string context)
                {
                    /*process request*/
                    Console.WriteLine("begin process two");
                    context = next(context);

                    /*process response*/
                    Console.WriteLine("end process two");
                    return context;
                }

                return Func;
            }

            return Middleware;
        }

    }
}
