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
        private const string searchServiceName = "TBD";
        private const string adminApiKey = "TBD";
        private const int batchs = 5000;
        private TimeSpan RequestTimeout = new TimeSpan(1, 0, 0);
        private TimeSpan RetryTimeout = new TimeSpan(0, 5, 0);
        private RetryPolicy retryPolicy = null;
        private SearchParameters parameters = null;
        private const int ONE_MS = 500000;

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

            //List<Task> tasks = new List<Task>();

            //for (int i = 0; i < 25; i++)
            //{
            //    tasks.Add(Task.Run(async () => {
            //        await run();
            //    }));
            //}

            //await Task.WhenAll(tasks);

            performanceTesting();

        }

        private void performanceTesting()
        {
            var projectIndexClients = new SearchIndexClient(searchServiceName, "costtask", new SearchCredentials(adminApiKey));

            projectIndexClients.HttpClient.Timeout = RequestTimeout;
            projectIndexClients.SetRetryPolicy(retryPolicy);

            try
            {
                var watch = new Stopwatch();
                watch.Start();

                ProjectNumbers.list.Take(100).ToList().ForEach(t =>
                {
                    //watch.Restart();
                    projectIndexClients.Documents.Search<CostTaskAzureSearchModel>(t, parameters);
                    //watch.Stop();
                    //Console.WriteLine("Total seconds:{0}", watch.Elapsed.TotalMilliseconds);

                });

                watch.Stop();
                Console.WriteLine("total Milliseconds:{0}", watch.Elapsed.TotalMilliseconds);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }


        }

        private void loadTesting()
        {
            var projectIndexClients = new SearchIndexClient(searchServiceName, "costproject", new SearchCredentials(adminApiKey));

            projectIndexClients.HttpClient.Timeout = RequestTimeout;
            projectIndexClients.SetRetryPolicy(retryPolicy);

            try
            {
                var watch = new Stopwatch();
                watch.Start();
                //watch.Stop();

                int i = 0;

                //Method 1 to control invoke a function per 10-16 milliseconds
                //Timer ter= new Timer(a =>{
                //    //watch.Restart();
                //    //watch.Stop();
                //    //Console.WriteLine("Total seconds:{0}", watch.Elapsed.TotalMilliseconds);
                //    //watch.Restart();
                //    Interlocked.Increment(ref i);


                //}, null,0,10);



                var spwatch = new Stopwatch();
                do
                {
                    //watch.Restart();
                    //Method 2 to control invoke a function per 10-15 milliseconds
                    SpinWait.SpinUntil(() => false, 10);

                    //Method 3 to control invoke a function per 10 milliseconds
                    //SpinWait.SpinUntil(() =>
                    //{
                    //    //var spwatch = new Stopwatch();
                    //    spwatch.Restart();
                    //    while (true)
                    //    {
                    //        if (spwatch.Elapsed.TotalMilliseconds >= 10)
                    //            return true;
                    //        Thread.SpinWait(1000);
                    //    }
                    //}, 10);


                    //Method 4 to control invoke a function per 10 milliseconds
                    //Thread.Sleep(10);

                    //Console.WriteLine("Total seconds:{0}", watch.Elapsed.TotalMilliseconds);

                    projectIndexClients.Documents.SearchAsync<CostProjectAzureSearchModel>(ProjectNumbers.list[i], parameters);
                    i++;
                } while (i < ProjectNumbers.list.Count());



                //Thread.Sleep(1000);
                //ter.Dispose();
                watch.Stop();
                Console.WriteLine("Total seconds:{0}", watch.Elapsed.TotalMilliseconds);
                Console.WriteLine(i);

                //var k = 0;
                //ProjectNumbers.list.ToList().ForEach(t =>
                //{
                //    watch.Restart();
                //    //projectIndexClients.Documents.Search<CostProjectAzureSearchModel>(t, parameters);

                //    Thread.SpinWait(10000);


                //    watch.Stop();
                //    Console.WriteLine("Total seconds:{0}", watch.Elapsed.Milliseconds);
                //    //Thread.Sleep(1);
                //    //projectIndexClients.Documents.SearchAsync<CostProjectAzureSearchModel>(t, parameters);
                //    //watch.Stop();
                //    //Console.WriteLine("Total seconds:{0}", watch.Elapsed.Milliseconds);

                //    //k++;
                //    //if (k % 50 == 0)
                //    //{
                //    //    watch.Stop();
                //    //    Console.WriteLine("Total seconds:{0}", watch.Elapsed.Milliseconds);
                //    //    //Thread.Sleep(500);

                //    //}


                //});
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
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


                ProjectNumbers.list.ToList().ForEach(t => tasks.Add(Task.Run(async () =>
                {
                    var elapsedMSec = watch.Elapsed.TotalMilliseconds;
                    await projectIndexClients.Documents.SearchAsync<CostProjectAzureSearchModel>(t, parameters);
                    Console.WriteLine("started in:{1}, complete in milliseconds:{0}", watch.Elapsed.TotalMilliseconds - elapsedMSec, elapsedMSec);
                })));

                await Task.WhenAll(tasks);

                Console.WriteLine("Total seconds:{0}", watch.Elapsed.TotalSeconds);
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }


        }
    }
}
