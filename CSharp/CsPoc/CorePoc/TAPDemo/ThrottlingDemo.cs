using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePoc.TAPDemo
{
    class ThrottlingDemo
    {
        public static async Task ExecuteAsync()
        {
            const int CONCURRENCY_LEVEL = 5;
            string[] urls = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            int nextIndex = 0;
            var cts = new CancellationTokenSource();
            var imageTasks = new List<Task<int>>();
            while (nextIndex < CONCURRENCY_LEVEL && nextIndex < urls.Length)
            {
                imageTasks.Add(GetCurrentPriceFromServer1Async(urls[nextIndex], cts.Token));
                nextIndex++;
            }

            while (imageTasks.Count > 0)
            {
                try
                {
                    Task<int> imageTask = await Task.WhenAny(imageTasks);
                    imageTasks.Remove(imageTask);

                    int image = await imageTask;
                    Console.WriteLine(image);
                }
                catch (Exception exc) {
                    Console.WriteLine(exc.Message);
                }

                if (nextIndex < urls.Length)
                {
                    imageTasks.Add(GetCurrentPriceFromServer1Async(urls[nextIndex], cts.Token));
                    nextIndex++;
                }
            }
        }

        private static async Task<int> GetCurrentPriceFromServer1Async(string str, CancellationToken ct)
        {
            await Task.Delay(1000, ct);
            return int.Parse(str);
        }

    }
}
