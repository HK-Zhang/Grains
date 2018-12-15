using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public static class TAPDemo
    {
        public static void Execute()
        {
            RetryOnFaultAsync().GetAwaiter().GetResult();
        }

        public static async Task RetryOnFaultAsync()
        {
            //string pageContents = await RetryOnFault(
            //    () => DownloadStringAsync("https://www.bynder.com"), 3);

            var pageContents = await DownloadStringAsync("https://www.bynder.com");
            Console.Write(pageContents);
        }


        public static async Task<T> RetryOnFault<T>(Func<Task<T>> function, int maxTries)
        {
            for (int i = 0; i < maxTries; i++)
            {
                try { return await function().ConfigureAwait(false); }
                catch { if (i == maxTries - 1) throw; }
            }
            return default(T);
        }

        public static async Task<string> DownloadStringAsync(string Url)
        {
            using (var httpClient = new HttpClient())
            using (var httpResonse = await httpClient.GetAsync(Url))
            {
                return await httpResonse.Content.ReadAsStringAsync();
            }
        }
    }


}
