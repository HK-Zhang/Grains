using StdTwoLib;
using System;

namespace CorePoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new ConfigReader();
            r.ReadConfig();
            Console.WriteLine("Hello World!");
        }
    }
}
