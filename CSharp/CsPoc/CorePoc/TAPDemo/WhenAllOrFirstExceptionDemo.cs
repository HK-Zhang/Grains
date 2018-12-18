using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePoc.TAPDemo
{
    class WhenAllOrFirstExceptionDemo
    {

        public static async Task ExecuteAsync()
        {
            var cts = new CancellationTokenSource();

            IEnumerable<Task<int>> tasks = new List<Task<int>>() {
                GetCurrentPriceFromServer1Async("msft", cts.Token),
                GetCurrentPriceFromServer2Async("msft", cts.Token),
                GetCurrentPriceFromServer3Async("msft", cts.Token),
                GetCurrentPriceFromServer4Async("msft", cts.Token) };

            var rst = await WhenAllOrFirstException(tasks);

            rst.ToList().ForEach(x => Console.WriteLine(x));
        }


        public static Task<T[]> WhenAllOrFirstException<T>(IEnumerable<Task<T>> tasks)
        {
            var inputs = tasks.ToList();
            var ce = new CountdownEvent(inputs.Count);
            var tcs = new TaskCompletionSource<T[]>();

            Action<Task> onCompleted = (Task completed) =>
            {
                if (completed.IsFaulted)
                    tcs.TrySetException(completed.Exception.InnerExceptions);
                if (ce.Signal() && !tcs.Task.IsCompleted)
                    tcs.TrySetResult(inputs.Select(t => t.Result).ToArray());
            };

            foreach (var t in inputs) t.ContinueWith(onCompleted);
            return tcs.Task;
        }

        private static async Task<int> GetCurrentPriceFromServer1Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            //Console.WriteLine("1.0");
            throw new Exception("Bad Request");
            return 1;
        }

        private static async Task<int> GetCurrentPriceFromServer2Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            //Console.WriteLine("2.0");
            return 2;
        }

        private static async Task<int> GetCurrentPriceFromServer3Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            //Console.WriteLine("3.0");
            return 3;
        }

        private static async Task<int> GetCurrentPriceFromServer4Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            //Console.WriteLine("4.0");
            return 4;
        }
    }
}
