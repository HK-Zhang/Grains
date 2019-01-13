using CorePoc.DataflowDemo;
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
                //await NeedOnlyOneDemo.ExecuteAsync();
                //await InterleavedDemo.ExecuteAsync();
                //await WhenAllOrFirstExceptionDemo.ExecuteAsync();
                //await AsyncCacheDemo.ExecuteAsync();
                //await AsyncProducerConsumerDemo.ExecuteAsync();
                //await BufferBlockDemocs.ExecuteAsync();
                //DataflowBlockCompletition.ExecuteAsync();
                //await ThrottlingDemo.ExecuteAsync();
                //await EarlyBailout.ExecuteAsync();
                //BufferingBlocks.ExecuteAsync();
                //BroadcastingBlock.ExecuteAsync();
                //WritingOnceBlock.ExecuteAsync();
                //ActionBlockDemo.ExecuteAsync();
                //TransformingBlock.ExecuteAsync();
                //TransformingManyBlock.ExecuteAsync();
                //BatchingBlock.ExecuteAsync();
                //JoiningBlock.ExecuteAsync();
                BatchedJoiningBlock.ExecuteAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
