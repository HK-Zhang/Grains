using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CsPoc
{
    class AOPCastleDemo
    {
        public static void Run()
        {
            ProxyGenerator pg = new ProxyGenerator();
            SimpleInterceptor si = new SimpleInterceptor();
            Person person = pg.CreateClassProxy<Person>(si);

            Console.WriteLine("Type:{0},Parent type:{1}",person.GetType(),person.GetType().BaseType);
            person.SayHello();
            person.SayName("ABC");
            person.SayOther();

        }
    }

    public class Person {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Birthday { get; set; }
        public virtual void SayHello()
        {
            Console.WriteLine("Hello");
        }

        public virtual void SayName(string name)
        {
            Console.WriteLine("Hello:" + name);
        }

        public void SayOther()
        {
            Console.WriteLine("Hi");
        }
    }

    public class SimpleInterceptor:StandardInterceptor  
    {
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("PreProceed Method Name is {0}", invocation.Method.Name);
            base.PreProceed(invocation);
        }

        protected override void PerformProceed(IInvocation invocation)
        {
            Console.WriteLine("PerformProceed Method Name is {0}", invocation.Method.Name);
            base.PerformProceed(invocation);
        }

        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("PostProceed Method Name is {0}", invocation.Method.Name);
            base.PostProceed(invocation);
        }
    }
}
