using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class CastleDynamicProxy
    {
        public void Execute()
        {
            Foo1();
        }

        public void Foo1()
        {
            ProxyGenerator generator = new ProxyGenerator();
            Castle.DynamicProxy.IInterceptor[] interceptors = { new MyCastleInterceptor() };
            CastleUserProcessor userProcessor = generator.CreateClassProxy<CastleUserProcessor>(interceptors);
            User user = new User() { Name = "lee", PassWord = "123123123123" };
            userProcessor.RegUser(user);
        }
    }


    public class CastleUserProcessor : IUserProcessor
    {
        public virtual void RegUser(User user)
        {
            Console.WriteLine("User is registered。Name:{0},PassWord:{1}", user.Name, user.PassWord);
        }
    }

    public class MyCastleInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            PreProceed(invocation);
            invocation.Proceed();
            PostProceed(invocation);
        }
        public void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("before action executed");
        }

        public void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("after action executed");
        }
    }
}
