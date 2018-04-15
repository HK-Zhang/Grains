using StdTwoLib;
using System;
using System.Configuration;

namespace CorePoc
{
    class Program
    {
        static void Main(string[] args)
        {
            //var d = new EnvDemo();
            //d.Execute();
            //var r = new ConfigReader();
            //r.ReadConfig();

            //Console.WriteLine("Hello World!");

            AzureDemo.Blob();

            Console.ReadLine();
        }
    }
}
