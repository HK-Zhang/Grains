using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemo
{
    public class AsyncContextDemo
    {

        public static void Execute()
        {
            //Foo1();
            //Foo2();
            Foo3();
        }

        private static void Foo1()
        {
            Task.Run(() => AsyncContextDemo.MainAsync()).Wait();
            //remove System.Console.ReadLine(); from main() to see result
        }

        private static void Foo2()
        {
            Task.Run(() => AsyncContextDemo.MainAsync()).Wait();
        }

        private static void Foo3()
        {
            Console.WriteLine("Master Thread ID:"+Thread.CurrentThread.ManagedThreadId);
            AsyncContext.Run(() => MainAsync());
            Console.WriteLine("Master Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            //remove System.Console.ReadLine(); from main() to see result
        }

        public static async void MainAsync()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            await new AsyncContextDemo().Backup();
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

        public async Task Backup()
        {
            var backupStatus = await BackupAsync();
            await Task.Delay(5000); //simulate some work
            Console.WriteLine(backupStatus);
        }


        public async Task<string> BackupAsync()
        {
            return await Task.Run(() => "Task Thread ID:" + Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }


}
