using StdTwoLib;
using System;
namespace RemoveAnytime
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new ConfigReader();
            Console.WriteLine(r.ReadConfig());

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
