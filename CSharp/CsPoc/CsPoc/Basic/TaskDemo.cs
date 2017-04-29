using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    class TaskDemo
    {
        public void Execute()
        {
            Foo1();
        }

        public void Foo1()
        {
            GetAsync().ContinueWith(new Action<Task<int>>(t => { Console.WriteLine(t.Result); }));
            Console.WriteLine(11);
        }

        public async Task<int> GetAsync()
        {
            var item = await GetOrDefaultAsync();
            return item;
        }

        public Task<int> GetOrDefaultAsync()
        {
            Thread.Sleep(2000);
            return Task.FromResult(10);
        }
    }
}
