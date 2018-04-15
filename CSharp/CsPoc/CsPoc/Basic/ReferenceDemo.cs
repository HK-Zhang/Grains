using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class ReferenceDemo
    {
        static void test(MyReferenceClass t) 
        {
            
            t = new MyReferenceClass();
            t.a = 2;
        }

        static void test2(ref MyReferenceClass t)
        {

            t = new MyReferenceClass();
            t.a = 2;
        }

        static MyReferenceClass doNothing()
        {
            var a = new MyReferenceClass();
            return a;
        }

        //static void doSomething(ref MyReferenceClass t)
        static void doSomething(MyReferenceClass t)
        {
            t = doNothing();
            t.a = 2;
        }

        public static void Execute() 
        {
            MyReferenceClass t1 = new MyReferenceClass();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(t1.a);
                //doSomething(ref t1);
                doSomething(t1);
                Console.WriteLine(t1.a);
            }


            Console.WriteLine(t1.a);
            test(t1);
            Console.WriteLine(t1.a);
            test2(ref t1);
            Console.WriteLine(t1.a);
        }


    }

    class MyReferenceClass
    {
        public int a = 1;

        public decimal? b { get; set; }
    }
}
