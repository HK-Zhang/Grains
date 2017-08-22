using StdTwoLib;
using System;
using System.Configuration;

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
