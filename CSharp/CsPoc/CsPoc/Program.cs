using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit+=CurrentDomain_ProcessExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //DynamicDemo dd = new DynamicDemo();
            //dd.VsObject();
            //dd.PropertyDemo();
            //dd.ReflectionDemo();
            //dd.ExpandoObjectDemo();
            //dd.DynamicProductDemo();
            //ReflectionDemo.Execute();
            //Singleton a = new Singleton();
            //StaticDemo.Execute();
            //ExtensionDemo.Execute();
            //LambdaDemo.Execute();

           // DelegateDemo ddemo = new DelegateDemo();
            //ReferenceDemo.Execute();
            //ReflectionDemo.RelectionTest();
            //PerformanceTest.Execute();
            //throw new Exception("err!!");

            //ddemo.Execute();

            ThreadDemo tdemo = new ThreadDemo();
            //tdemo.Test1Foo();
            //tdemo.Test2Foo();
            //tdemo.Test3Foo();
            //tdemo.Test4Foo();
            //tdemo.Test5Foo();
            //tdemo.Test6Foo();
            AsyncTest.Run3();


            

            Console.ReadLine();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText(@"F:\VS\CsPoc\CsPoc\bin\log.txt", ((Exception)e.ExceptionObject).StackTrace);
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            File.WriteAllText(@"F:\VS\CsPoc\CsPoc\bin\log.txt", ((AppDomain)sender).FriendlyName);
        }
    }
}
