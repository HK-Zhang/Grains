using CorePoc.TAPDemo;
using StdTwoLib;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace CorePoc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var d = new EnvDemo();
            //d.Execute();
            //var r = new ConfigReader();
            //r.ReadConfig();

            //Console.WriteLine("Hello World!");

            //AzureDemo.Blob();

            //Console.ReadLine();
            try
            {
                //await Retry.ExecuteAsync();
                await NeedOnlyOneDemo.ExecuteAsync();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
