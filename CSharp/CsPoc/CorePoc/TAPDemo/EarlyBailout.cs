using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePoc.TAPDemo
{
    class EarlyBailout
    {
        public static async Task ExecuteAsync()
        {
            await Foo1();
        }

        private static async Task Foo1()
        {
            var m_cts = new CancellationTokenSource();
            try
            {
                Task<int> imageDownload = GetCurrentPriceFromServer1Async("1", m_cts.Token);
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    m_cts.Cancel();
                });

                //var rst = await imageDownload;
                //Console.WriteLine(rst);

                var rst = await UntilCompletionOrCancellation(imageDownload, m_cts.Token);
                if (imageDownload.IsCompleted)
                {
                    Console.WriteLine(imageDownload.Result);
                }
                else
                {
                    Console.WriteLine(rst);
                    //imageDownload.ContinueWith(t => Console.WriteLine(t));
                };
            }
            finally { }
        }

        private static async Task<int> GetCurrentPriceFromServer1Async(string str, CancellationToken ct)
        {
            await Task.Delay(3000,ct);
            Console.WriteLine("1.0");
            return 1;
        }

        private static async Task<T> UntilCompletionOrCancellation<T>(Task<T> asyncOp, CancellationToken ct) where T : new()
        {
            //T a = new T();
            var tcs = new TaskCompletionSource<T>();
            using (ct.Register(() => tcs.TrySetResult(default)))
                return await Task.WhenAny(asyncOp, tcs.Task).Result;
            //return asyncOp;
        }
    }
}
