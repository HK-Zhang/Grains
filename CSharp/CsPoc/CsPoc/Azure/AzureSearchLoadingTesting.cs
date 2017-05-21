using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TERS.Infrastructure.Search.Model;

namespace CsPoc.Azure
{
    public class AzureSearchLoadingTesting
    {
        private const string searchServiceName = "tbd";
        private const string adminApiKey = "tbd";
        private const int batchs = 5000;
        private TimeSpan RequestTimeout = new TimeSpan(1, 0, 0);
        private TimeSpan RetryTimeout = new TimeSpan(0, 5, 0);
        private RetryPolicy retryPolicy = null;
        private SearchParameters parameters = null;

        public async void Execute()
        {

            retryPolicy = new RetryPolicy(new HttpStatusCodeErrorDetectionStrategy(), 5, RetryTimeout);

            int maxThreadNum, maxPortThreadNum;

            int minThreadNum, minPortThreadNum;

            ThreadPool.GetMaxThreads(out maxThreadNum, out maxPortThreadNum);

            ThreadPool.SetMinThreads(200, 1000);
            //ThreadPool.SetMaxThreads(250, maxPortThreadNum);

            ThreadPool.GetMaxThreads(out maxThreadNum, out maxPortThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out minPortThreadNum);

            Console.WriteLine("max thread num：{0}", maxThreadNum);

            Console.WriteLine("min thread num：{0}", minThreadNum);

            Console.WriteLine("max io thread num：{0}", maxPortThreadNum);

            Console.WriteLine("min io thread num：{0}", minPortThreadNum);

            parameters = new SearchParameters()
            {
                SearchFields = new[] { "ProjectNo" },
                //Select = new[] { "ProjectName" 
            };

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 25; i++)
            {
                tasks.Add(Task.Run(async () => {
                    await run();
                }));
            }

            await Task.WhenAll(tasks);
        }

        private async Task run()
        {
            var projectIndexClients = new SearchIndexClient(searchServiceName, "costproject", new SearchCredentials(adminApiKey));

            projectIndexClients.HttpClient.Timeout = RequestTimeout;
            projectIndexClients.SetRetryPolicy(retryPolicy);

            List<Task> tasks = new List<Task>();

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                ProjectNumbers.list.ToList().ForEach(t => tasks.Add(Task.Run(async () => {
                    var elapsedMSec = watch.Elapsed.TotalMilliseconds;
                    await projectIndexClients.Documents.SearchAsync<CostProjectAzureSearchModel>(t, parameters);
                    Console.WriteLine("started in:{1}, complete in milliseconds:{0}", watch.Elapsed.TotalMilliseconds - elapsedMSec, elapsedMSec);
                })));

                await Task.WhenAll(tasks);

                Console.WriteLine("Total seconds:{0}", watch.Elapsed.TotalSeconds);
                watch.Stop();
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
            

        }
    }
}
