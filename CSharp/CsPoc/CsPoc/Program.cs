using CsPoc.Basic;
using CsPoc.Collection;
using CsPoc.ThreadTest;
using CsPoc.ThreadNS;
using CsPoc.Toolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsPoc.Advanced;
using CsPoc.Reflections;
using CsPoc.Network;
using CsPoc.DynamicFramework;
using CSDemo;
using CsPoc.ThreadDemos;
using CsPoc.XML;
using CsPoc.Azure;
using CsPoc.FP;
using CsPoc.STD;

namespace CsPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit+=CurrentDomain_ProcessExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            #region

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

            //ThreadDemo tdemo = new ThreadDemo();
            //tdemo.Test1Foo();
            //tdemo.Test2Foo();
            //tdemo.Test3Foo();
            //tdemo.Test4Foo();
            //tdemo.Test5Foo();
            //tdemo.Test6Foo();
            //tdemo.Test7Foo();
            //tdemo.Test8Foo();
            //AsyncTest.Run3();
            //SynchronizationDemo sdemo = new SynchronizationDemo();
            //sdemo.Run();
            //sdemo.Run2();

            //AsyncDelegateDemo ad = new AsyncDelegateDemo();
            //ad.TestEnd();
            //ad.TestCallback();

            //StringFormatDemo.Foo();
            //StringFormatDemo.Foop();
            //StringFormatDemo.Food();

            #endregion
            //AutofacDemo.BasicRun();
            //AutofacDemo.ResolveFoo();
            //AutofacDemo.RegisterFoo();
            //AutofacDemo.LambdaFoo();
            //AutofacDemo.RegisterFoo2();
            //AutofacDemo.RegisterFoo3();
            //AutofacDemo.IOCFoo();
            //AutofacDemo.IOCLambdaFoo();
            //AutofacDemo.IOCMethodFoo();
            //AutofacDemo.IterfaceFoo();
            //AutofacDemo.EventFoo2();
            //AOPCastleDemo.Run();

            //CSDemo.AsyncDemonstration AD = new CSDemo.AsyncDemonstration();
            //AD.Run();
            //InOutDemo.RUN();
            //AttributeDemo.RunDemo();

            //ParallelDemo.RunDemo();

            //DynamicDemo dd = new DynamicDemo();
            //dd.XMLDemo();

            //EventDemo.RunDemo();


            //LinqDemo.RunDemo();
            //ImmutableDemo demo = new ImmutableDemo();
            //demo.Excecute();

            //AsyncLockDemo ad = new AsyncLockDemo();
            //SpinLockDemo ad = new SpinLockDemo();
            //TypeListDemo ad = new TypeListDemo();
            //ad.Execute();

            //CSDemo.LazySingletonDemo.Execute();
            //            MemoryCacheDemo.Execute();
            //TaskDemo td = new TaskDemo();
            //td.Execute();


            //ParallelDemo.RunDemo();

            //JsonNetDemo jd = new JsonNetDemo();
            //jd.Execute();

            //            ReadonlyCollectionDemo tcd = new ReadonlyCollectionDemo();
            //            JsonDemo tcd = new JsonDemo();

//            FPdemo tcd = new FPdemo();
//            CallerDemo tcd = new CallerDemo();
//            tcd.Execute();

            //ThreadSafeDicDemo td = new ThreadSafeDicDemo();
            //td.Execute();

            //CultureInfoDemo gi = new CultureInfoDemo();
            //gi.Execute();

            //AsyncResultDemo ad = new AsyncResultDemo();
            //ad.Run();

            //RealAsyncResultDemo rd = new RealAsyncResultDemo();
            //rd.Execute();
            //AwaitDemo ad = new AwaitDemo();
            //ad.Execute();

            //SerializeDemo sd = new SerializeDemo();
            //sd.Execute();

            //MethodDemo md = new MethodDemo();
            //md.Execute();

            //TaskCompletionSourceDemo rcsd = new TaskCompletionSourceDemo();
            //rcsd.Execute();

            //WaitAwaitDemo.Execute();

            //HttpBindingDemo hd = new HttpBindingDemo();
            //hd.Execute();

            //CastleProxyDemo cd = new CastleProxyDemo();
            //cd.Execute();


            //            InheritenceDemo.Execute();
            //EqualsDemo.Execute();

            //CastleAutoDemo.Execute();

            //CastleDIDemo cd = new CastleDIDemo();
            //cd.Execute();

            //ThreadUniqueID td = new ThreadUniqueID();
            //td.Execute();

            //XSLTExt xb = new XSLTExt();
            //xb.Execute();

            //XsltBasic xb = new XsltBasic();
            //xb.Execute();

            //XSLTCS xs = new XSLTCS();
            //xs.Execute();

            //AzureStorageDemo asd = new AzureStorageDemo();
            //asd.Execute();

            try
            {

//                EnumDemo ed = new EnumDemo();
//                ed.Execute();
                TimerDemo.Execute();
                //AzureSearchLoadingTesting d = new AzureSearchLoadingTesting();
                //d.Execute();

                //HashSetDemo hd = new HashSetDemo();
                //hd.Execute();

                //ReferenceDemo md = new ReferenceDemo();
                //md.Execute();

                //ReferenceDemo.Execute();

                //EnumeratorDemo td = new EnumeratorDemo();
                //td.Execute();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText(@"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\bin\log.txt", ((Exception)e.ExceptionObject).StackTrace);
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\yxzhk\WorkSpace\CodeDemo\CsPoc\CsPoc\bin\log.txt", ((AppDomain)sender).FriendlyName);
        }
    }
}
