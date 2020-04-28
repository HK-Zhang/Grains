using CorePoc.DataflowDemo;
using CorePoc.DataParallelism;
using CorePoc.TAPDemo;
using StdTwoLib;
using System;
using System.Configuration;
using System.Threading.Tasks;
using CorePoc.Basic;
using CorePoc.Picture;
using CorePoc.Tools;

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
                //BatchedJoiningBlock.ExecuteAsync();
                //DataflowProducerConsumer.ExecuteAsync();
                //DataflowExecutionBlocks.ExecuteAsync();
                //DataflowReversedWords.ExecuteAsync();
                //DataflowReceiveAny.ExecuteAsync();
                //JointMutipleResource.Execute();
                //ParallelismDegree.ExecuteAsync();
                //SimpleParallelFor.Execute();
                //LoopThreadLocal.Execute();
                //                ParalleCancel.Execute();
                //                HtmlToDoc.Execute();
                //                StringCipher.Execute();
                //                TextPDF.Execute();
                //                DigitalSigning.Execute();
                //                EncryptImage.Execute();
                //                IdGenerator.Execute();
                //                ImageConvertor.Execute();
                //                ImageHelper.Execute();
                //FileMonitor.Execute();
                HttpClientDemo.Execute();
            }



            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
