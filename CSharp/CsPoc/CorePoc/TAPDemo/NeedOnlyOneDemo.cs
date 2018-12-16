using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePoc.TAPDemo
{
    class NeedOnlyOneDemo
    {
        public static async Task ExecuteAsync()
        {
            double currentPrice = await NeedOnlyOne(
                ct => GetCurrentPriceFromServer1Async("msft", ct),
                ct => GetCurrentPriceFromServer2Async("msft", ct),
                ct => GetCurrentPriceFromServer3Async("msft", ct),
                ct => GetCurrentPriceFromServer4Async("msft", ct));

            Console.WriteLine(currentPrice);
        }

        public static async Task<T> NeedOnlyOne<T>(params Func<CancellationToken, Task<T>>[] functions)
        {
            var cts = new CancellationTokenSource();
            var tasks = (from function in functions
                         select function(cts.Token)).ToArray();
            var completed = await Task.WhenAny(tasks).ConfigureAwait(false);
            cts.Cancel();
            foreach (var task in tasks)
            {
                var ignored = task.ContinueWith(t => Log(t), TaskContinuationOptions.OnlyOnFaulted);
            }

            return completed.Result;
        }

        private static void Log(Task t)
        {
            Console.WriteLine($"Task {t.Id} was cancelled.");
        }

        private static async Task<double> GetCurrentPriceFromServer1Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000);
            return 1.0;
        }

        private static async Task<double> GetCurrentPriceFromServer2Async(string str, CancellationToken ct)
        {
            await Task.Delay(2000, ct);
            Console.WriteLine("2.0");
            return 2.0;
        }

        private static async Task<double> GetCurrentPriceFromServer3Async(string str, CancellationToken ct)
        {
            await Task.Delay(3000);
            //await Task.Delay(3000, ct);
            Console.WriteLine("3.0");
            return 3.0;
        }

        private static async Task<double> GetCurrentPriceFromServer4Async(string str, CancellationToken ct)
        {
            TaskCompletionSource<double> tcs = new TaskCompletionSource<double>();

            await Task.Delay(4000);

            if (ct.IsCancellationRequested)
            {
                tcs.SetCanceled();
            }
            else
            {
                Console.WriteLine("4.0");
                tcs.SetResult(4.0);
            }

            return await tcs.Task;
        }
    }
}
