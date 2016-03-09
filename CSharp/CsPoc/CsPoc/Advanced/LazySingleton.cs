using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemo
{
    public class LazySingleton
    {
        //Lazy singleton
        private LazySingleton() { }
        public static readonly Lazy<LazySingleton> instance = new Lazy<LazySingleton>(() => { return new LazySingleton(); });

        //not lazy Singleton
        //public static readonly LazySingleton instance = new LazySingleton();

        public String Name { get; set; }
    }

    public class LazySingletonDemo
    {
        public static void Execute()
        {
            Task.Run(() => Foo1());
            Thread.Sleep(1000);
            Task.Run(() => Foo1());
            Task.Run(() => Foo1());
          
        }

        public static void Foo1()
        {
            if (!LazySingleton.instance.IsValueCreated)
                Console.WriteLine("LazySingleton is not initialized");

            LazySingleton.instance.Value.Name = "HK";

            Console.WriteLine(LazySingleton.instance.Value.Name);
        }
    }
}
