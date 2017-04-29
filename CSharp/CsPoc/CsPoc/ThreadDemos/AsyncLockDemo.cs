using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc
{
    public class AsyncLockDemo
    {
        //private readonly object _mutex = new object();
        private readonly AsyncLock _mutex = new AsyncLock();
        private int i = 0;
        public void Execute()
        {
            Console.WriteLine("before call foo1: "+ i);

            Foo1().ContinueWith(new Action<Task>(t =>
            {
                Console.WriteLine("foo1 completed: " + i);
            }));

            Console.WriteLine("after call foo1: " + i);

            Console.WriteLine("before call foo2: " + i);

            Foo2().ContinueWith(new Action<Task>(t =>
            {
                Console.WriteLine("foo2 completed: " + i);
            }));

            Console.WriteLine("after call foo2: " + i);
        }

        public async Task Foo1()
        {
            using (await _mutex.LockAsync())
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine("Foo1 start: " + i);
                await DoSomethingAsync(1);
                Console.WriteLine("Foo1 end: " + i);
            }
        }

        public async Task Foo2()
        {
            using (await _mutex.LockAsync())
            {
                Console.WriteLine("Foo2 start: " + i);
                //await Task.Delay(TimeSpan.FromSeconds(1));
                await DoSomethingAsync(2);
                Console.WriteLine("Foo2 end: " + i);
            }
        }

        private Task DoSomethingAsync(int j)
        {
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                i = j;
            });
        }
    }

    
}
