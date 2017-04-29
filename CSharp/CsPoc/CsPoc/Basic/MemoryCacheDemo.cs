using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    public class MemoryCacheDemo
    {
        public static void Execute()
        {
            Foo1();
        }

        private static void Foo1() 
        {
            ObjectCache cache = MemoryCache.Default;
            string fileContents = cache["filecontents"] as string;

            if (fileContents == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();

                List<string> filePaths = new List<string>();
                filePaths.Add(@"F:\VS\CsPoc\CsPoc\bin\log.txt");

                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                // Fetch the file contents.
                fileContents = File.ReadAllText(@"F:\VS\CsPoc\CsPoc\bin\log.txt");

                cache.Set("filecontents", fileContents, policy);
            }

            fileContents = cache["filecontents"] as string;

            Console.Write(fileContents);

            Thread.Sleep(5000);
            fileContents = cache["filecontents"] as string;
            Console.Write(fileContents);
        }
    }
}
