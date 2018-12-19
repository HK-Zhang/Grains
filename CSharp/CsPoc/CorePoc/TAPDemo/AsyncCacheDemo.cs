using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CorePoc.TAPDemo
{
    class AsyncCacheDemo
    {
        private static AsyncCache<string, string> m_webPages = new AsyncCache<string, string>(DownloadStringAsync);
        private static async Task<string> DownloadStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            using (var httpResonse = await httpClient.GetAsync(url))
            {
                return await httpResonse.Content.ReadAsStringAsync();
            }
        }

        public static async Task ExecuteAsync()
        {
            var rst = await m_webPages["https://www.microsoft.com"];
            Console.Write(rst);
        }
    }

    public class AsyncCache<TKey, TValue>
    {
        private readonly Func<TKey, Task<TValue>> _valueFactory;
        private readonly ConcurrentDictionary<TKey, Lazy<Task<TValue>>> _map;

        public AsyncCache(Func<TKey, Task<TValue>> valueFactory)
        {
            if (valueFactory == null) throw new ArgumentNullException("loader");
            _valueFactory = valueFactory;
            _map = new ConcurrentDictionary<TKey, Lazy<Task<TValue>>>();
        }

        public Task<TValue> this[TKey key]
        {
            get
            {
                if (key == null) throw new ArgumentNullException("key");
                return _map.GetOrAdd(key, toAdd =>
                    new Lazy<Task<TValue>>(() => _valueFactory(toAdd))).Value;
            }
        }
    }
}
