using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePoc.TAPDemo
{
    class InterleavedDemo
    {
        public static async Task ExecuteAsync()
        {
            var cts = new CancellationTokenSource();

            IEnumerable<Task<int>> tasks = new List<Task<int>>() {
                GetCurrentPriceFromServer1Async("msft", cts.Token),
                GetCurrentPriceFromServer2Async("msft", cts.Token),
                GetCurrentPriceFromServer3Async("msft", cts.Token),
                GetCurrentPriceFromServer4Async("msft", cts.Token) };

            foreach (var task in Interleaved(tasks))
            {
                Console.WriteLine(task.Id);
                int result = await task;

                if (task.Id > 10)
                {
                    cts.Cancel();
                }

                if (task.IsCompleted)
                {
                    Console.WriteLine($"{task.Id},{result}");
                }
            }
        }

        static IEnumerable<Task<T>> Interleaved<T>(IEnumerable<Task<T>> tasks)
        {
            var inputTasks = tasks.ToList();
            var sources = (from _ in Enumerable.Range(0, inputTasks.Count)
                           select new TaskCompletionSource<T>()).ToList();
            int nextTaskIndex = -1;
            foreach (var inputTask in inputTasks)
            {
                inputTask.ContinueWith(completed =>
                {
                    var source = sources[Interlocked.Increment(ref nextTaskIndex)];

                    if (completed.IsFaulted)
                        source.TrySetException(completed.Exception.InnerExceptions);
                    else if (completed.IsCanceled)
                        source.TrySetCanceled();
                    else
                        source.TrySetResult(completed.Result);
                }, CancellationToken.None,
                   TaskContinuationOptions.ExecuteSynchronously,
                   TaskScheduler.Default);
            }

            return from source in sources
                   select source.Task;
        }

        private static async Task<int> GetCurrentPriceFromServer1Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            Console.WriteLine("1.0");
            return 1;
        }

        private static async Task<int> GetCurrentPriceFromServer2Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            Console.WriteLine("2.0");
            return 2;
        }

        private static async Task<int> GetCurrentPriceFromServer3Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            Console.WriteLine("3.0");
            return 3;
        }

        private static async Task<int> GetCurrentPriceFromServer4Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            Console.WriteLine("4.0");
            return 4;
        }
    }
}
