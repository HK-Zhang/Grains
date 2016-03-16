using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System.Reflection;

namespace CSDemo
{
    public class CastleInterceptor
    {
        public void Execute()
        {
            Foo1();
        }

        public void Foo1()
        {
            ProxyGenerator generator = new ProxyGenerator();
            //Castle.DynamicProxy.IInterceptor[] interceptors = { new MyCastleInterceptor() };
            var options = new ProxyGenerationOptions(new InterceptorFilter()) { Selector = new InterceptorSelector() };
            CastleUserProcessor userProcessor = generator.CreateClassProxy<CastleUserProcessor>(options,new MyCastleInterceptor(), new SimpleLogInterceptor());
            User user = new User() { Name = "lee", PassWord = "123123123123" };
            userProcessor.RegUser(user);
        }
    }

    public class SimpleLogInterceptor : Castle.DynamicProxy.IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(">>" + invocation.Method.Name);
            invocation.Proceed();
        }
    }

    public class InterceptorSelector : IInterceptorSelector
    {
        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            if (method.Name.StartsWith("set_")) return interceptors;
            else return interceptors.Where(i => i is MyCastleInterceptor).ToArray<Castle.DynamicProxy.IInterceptor>();
        }
    }
    public class InterceptorFilter : IProxyGenerationHook
    {
        public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
        {
            //return memberInfo.IsSpecialName && (memberInfo.Name.StartsWith("set_") || memberInfo.Name.StartsWith("get_"));
            return true;
        }
        public void NonVirtualMemberNotification(Type type, MemberInfo memberInfo)
        {
        }
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            throw new NotImplementedException();
        }
    }
}
