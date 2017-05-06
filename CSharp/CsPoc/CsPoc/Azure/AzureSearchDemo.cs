﻿using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Rest.Azure;
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
    public class AzureSearchDemo
    {
        private const string searchServiceName = "tbd";
        private const string adminApiKey = "tbd";
        private SearchServiceClient serviceClient;
        private SearchIndexClient projectIndexClient;
        private SearchIndexClient taskIndexClient;


        public async void Execute()
        {
            serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));

            projectIndexClient = new SearchIndexClient(searchServiceName, "costproject", new SearchCredentials(adminApiKey));
            taskIndexClient = new SearchIndexClient(searchServiceName, "costtask", new SearchCredentials(adminApiKey));
            //downlaod();
            //await FindIndex("costproject");
            //await Search();

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

        private void PerformanceTest() {
            int maxThreadNum, portThreadNum;

            int minThreadNum;

            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);

            ThreadPool.SetMinThreads(200, portThreadNum);
            ThreadPool.SetMaxThreads(250, portThreadNum);

            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);



            Console.WriteLine("max thread num：{0}", maxThreadNum);

            Console.WriteLine("min thread num：{0}", minThreadNum);

            SearchParameters parameters =
              new SearchParameters()
              {
                  SearchFields = new[] { "ProjectNo" },
                    //Select = new[] { "ProjectName" }
                };


            Stopwatch timer = new Stopwatch();
            timer.Start();

            System.Threading.Tasks.Parallel.For(0, 200, new ParallelOptions { MaxDegreeOfParallelism = 200 }, (i) =>
            {
                //Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                var r = projectIndexClient.Documents.Search<CostProjectAzureSearchModel>("10006685", parameters);
                //WriteProjectDocuments(r);
            });

            timer.Stop();
            Console.WriteLine("Elapsed 1" + ": " + timer.Elapsed.ToString());

            timer.Restart();

            System.Threading.Tasks.Parallel.For(0, 200, new ParallelOptions { MaxDegreeOfParallelism = 200 }, (i) =>
            {
                //Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                var r = projectIndexClient.Documents.Search<CostProjectAzureSearchModel>("10006685", parameters);
                //WriteProjectDocuments(r);
            });

            timer.Stop();
            Console.WriteLine("Elapsed 2" + ": " + timer.Elapsed.ToString());

            timer.Restart();

            System.Threading.Tasks.Parallel.For(0, 200, new ParallelOptions { MaxDegreeOfParallelism = 200 }, (i) =>
            {
                //Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                var r = projectIndexClient.Documents.Search<CostProjectAzureSearchModel>("10006685", parameters);
                //WriteProjectDocuments(r);
            });

            timer.Stop();
            Console.WriteLine("Elapsed 3" + ": " + timer.Elapsed.ToString());

            timer.Restart();

            System.Threading.Tasks.Parallel.For(0, 200, new ParallelOptions { MaxDegreeOfParallelism = 200 }, (i) =>
            {
                //Console.WriteLine("{0},{1},{2}", i, DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                var r = projectIndexClient.Documents.Search<CostProjectAzureSearchModel>("10006685", parameters);
                //WriteProjectDocuments(r);
            });

            timer.Stop();
            Console.WriteLine("Elapsed 4" + ": " + timer.Elapsed.ToString());
        }
    }
}
