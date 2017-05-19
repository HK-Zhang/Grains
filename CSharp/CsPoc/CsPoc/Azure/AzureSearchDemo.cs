using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TERS.Infrastructure.Search.Model;

namespace CsPoc.Azure
{
    public class AzureSearchDemo
    {
        private const string searchServiceName = "tbd";
        private const string adminApiKey = "tbd";
        private SearchServiceClient serviceClient;
        private SearchIndexClient projectIndexClient;
        private SearchIndexClient taskIndexClient;
        private int loopsum;
        private const int batchs = 5000;
        private List<SearchIndexClient> projectIndexClients;
        private Random ro = new Random(10);
        public async void Execute()
        {

            //long a = 1;
            //Console.WriteLine(string.Format("{0}",a));
            ServicePointManager.DefaultConnectionLimit = 1000;
            serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));

            projectIndexClient = new SearchIndexClient(searchServiceName, "costproject", new SearchCredentials(adminApiKey));
            taskIndexClient = new SearchIndexClient(searchServiceName, "costtask", new SearchCredentials(adminApiKey));
            projectIndexClient.HttpClient.Timeout = new TimeSpan(0, 5, 0);
            //downlaod();
            //await FindIndex("costproject");
            //await Search();

            projectIndexClients = new List<SearchIndexClient>();
            for (int i = 0; i <= 10; i++)
            {
                projectIndexClients.Add(new SearchIndexClient(searchServiceName, "costproject", new SearchCredentials(adminApiKey)));
                projectIndexClients[i].HttpClient.Timeout = new TimeSpan(0, 5, 0);
            }


            PerformanceTest();
        }


        private async Task FindIndex(string indexName)
        {


            try
            {
                var indexDefinition = await serviceClient.Indexes.GetAsync(indexName);

                if (indexDefinition == null)
                {
                }
            }
            catch (CloudException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }

        }

        private async Task Search()
        {
            SearchParameters parameters;
            DocumentSearchResult<CostProjectAzureSearchModel> projectresults;
            DocumentSearchResult<CostTaskAzureSearchModel> taskresults;

            parameters =
                new SearchParameters()
                {
                    SearchFields = new[] { "ProjectNo" },
                    //Select = new[] { "ProjectName" }
                };

            SearchParameters taskparameters =
                new SearchParameters()
                {
                    Filter = "ProjectNo eq '10006685'",
                    //SearchFields = new[] { "ProjectNo" },
                    //Select = new[] { "ProjectName" }
                };

            Stopwatch timer = new Stopwatch();
            timer.Start();
            projectresults = await projectIndexClient.Documents.SearchAsync<CostProjectAzureSearchModel>("10006685", parameters);
            taskresults = await taskIndexClient.Documents.SearchAsync<CostTaskAzureSearchModel>("*", taskparameters);

            timer.Stop();

            Console.WriteLine("Elapsed" + ": " + timer.Elapsed.ToString());

            WriteProjectDocuments(projectresults);
            WriteTaskDocuments(taskresults);

        }

        private void WriteProjectDocuments(DocumentSearchResult<CostProjectAzureSearchModel> searchResults)
        {
            foreach (SearchResult<CostProjectAzureSearchModel> result in searchResults.Results)
            {
                Console.WriteLine(result.Document.ProjectName);
            }

            Console.WriteLine();
        }

        private void WriteTaskDocuments(DocumentSearchResult<CostTaskAzureSearchModel> searchResults)
        {
            foreach (SearchResult<CostTaskAzureSearchModel> result in searchResults.Results)
            {
                Console.WriteLine(result.Document.TaskName);
            }

            Console.WriteLine();
        }

        private void PerformanceTest()
        {
            int maxThreadNum, maxPortThreadNum;

            int minThreadNum, minPortThreadNum;

            ThreadPool.GetMaxThreads(out maxThreadNum, out maxPortThreadNum);

            ThreadPool.SetMinThreads(200, batchs);
            //ThreadPool.SetMaxThreads(250, maxPortThreadNum);

            ThreadPool.GetMaxThreads(out maxThreadNum, out maxPortThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out minPortThreadNum);



            Console.WriteLine("max thread num：{0}", maxThreadNum);

            Console.WriteLine("min thread num：{0}", minThreadNum);

            Console.WriteLine("max io thread num：{0}", maxPortThreadNum);

            Console.WriteLine("min io thread num：{0}", minPortThreadNum);



            SearchParameters parameters =
              new SearchParameters()
              {
                  SearchFields = new[] { "ProjectNo" },
                  //Select = new[] { "ProjectName" }
              };


            Stopwatch timer = new Stopwatch();
            timer.Start();
            int successreq = 0;
            loopsum = 0;
            System.Threading.Tasks.Parallel.For(0, batchs, /*new ParallelOptions { MaxDegreeOfParallelism = 200 },*/ async (i) =>
            {
                //Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                try
                {
                    await projectIndexClients[i / 500].Documents.SearchAsync<CostProjectAzureSearchModel>(ProjectNumbers.list[i / 5], parameters);
                    //Console.WriteLine(r.Results[0].Document.ProjectName);
                    Interlocked.Add(ref successreq, 1);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
                finally
                {
                    Interlocked.Add(ref loopsum, 1);
                }

                //WriteProjectDocuments(r);
            });



            while (loopsum != batchs)
            {
                Thread.Sleep(100);
            }

            timer.Stop();
            Console.WriteLine("Elapsed 1" + ": " + timer.Elapsed.ToString() + "," + successreq);


            for (int j = 2; j < 10; j++)
            {
                timer.Restart();
                loopsum = 0;
                successreq = 0;
                System.Threading.Tasks.Parallel.For(0, batchs, /*new ParallelOptions { MaxDegreeOfParallelism = 200 },*/ async (i) =>
                {
                    //Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                    try
                    {
                        await projectIndexClients[i / 500].Documents.SearchAsync<CostProjectAzureSearchModel>(ProjectNumbers.list[i / 5], parameters);
                        //Console.WriteLine(r.Results[0].Document.ProjectName);
                        Interlocked.Add(ref successreq, 1);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Interlocked.Add(ref loopsum, 1);
                    }

                    //WriteProjectDocuments(r);
                });

                while (loopsum != batchs)
                {
                    Thread.Sleep(100);
                }

                timer.Stop();
                Console.WriteLine("Elapsed " + j + ": " + timer.Elapsed.ToString() + "," + successreq);
            }


            //return;

            //timer.Restart();
            //loopsum = 0;
            //System.Threading.Tasks.Parallel.For(0, batchs, /*new ParallelOptions { MaxDegreeOfParallelism = 200 },*/ async (i) =>
            //{
            //    Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
            //    try
            //    {
            //        await projectIndexClient.Documents.SearchAsync<CostProjectAzureSearchModel>("10006685", parameters);
            //        Console.WriteLine(r.Results[0].Document.ProjectName);

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //    finally
            //    {
            //        Interlocked.Add(ref loopsum, 1);
            //    }

            //    WriteProjectDocuments(r);
            //});

            //while (loopsum != batchs)
            //{
            //    Thread.Sleep(100);
            //}

            //timer.Stop();
            //Console.WriteLine("Elapsed 3" + ": " + timer.Elapsed.ToString());

            //timer.Restart();
            //loopsum = 0;
            //System.Threading.Tasks.Parallel.For(0, batchs, /*new ParallelOptions { MaxDegreeOfParallelism = 200 },*/ async (i) =>
            //{
            //    Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
            //    try
            //    {
            //        await projectIndexClient.Documents.SearchAsync<CostProjectAzureSearchModel>("10006685", parameters);
            //        Console.WriteLine(r.Results[0].Document.ProjectName);

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //    finally
            //    {
            //        Interlocked.Add(ref loopsum, 1);
            //    }

            //    WriteProjectDocuments(r);
            //});

            //while (loopsum != batchs)
            //{
            //    Thread.Sleep(100);
            //}

            //timer.Stop();
            //Console.WriteLine("Elapsed 4" + ": " + timer.Elapsed.ToString());

        }
    }
}
