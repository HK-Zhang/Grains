using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.DynamicFramework
{
    public class CastleProxyDemo
    {

        public void Execute()
        {
            TestFoo();
            //Foo1();
        }
        public void TestFoo()
        {
            var container = new WindsorContainer();

            container.Register(
                Component.For<FooService, IFooService>(),
                Component.For(typeof(FooInterceptor)).LifestyleTransient(),
                Component.For(typeof(FooController)).Proxy.AdditionalInterfaces(typeof(IFooService))
                .Interceptors(typeof(FooInterceptor)).LifestyleTransient() );

            var obj = container.Resolve<FooController>();

            MethodInfo method = obj.GetType().GetMethod("Do");
            method.Invoke(obj, null);

            //IFoo objA = obj as IFoo;
            //objA.Do();
            //Console.WriteLine(method.DeclaringType);

        }

        private void Foo1()
        {
            var container = new WindsorContainer();
            container.Register(
                Component.For<FooService, IFooService>()
                );

            ProxyGenerator generator = new ProxyGenerator();
            var options = new ProxyGenerationOptions();
            options.AddMixinInstance(new FooService());
            FooController objB = generator.CreateClassProxy<FooController>(options, new FooInterceptor(new FooService()));

            IFooService objA = objB as IFooService;
            objA.Do();

        }
    }

    public interface IFooService 
    {
        void Do();
    }

    public class FooService : IFooService
    {
        public void Do()
        {
            Console.WriteLine("How are you doing?");
        }

    }
    public class FooController 
    {

    }

    public class FooInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly IFooService _proxiedObject;

        public FooInterceptor()
        { 
        }

        public FooInterceptor(IFooService proxiedObject)
        {
            _proxiedObject = proxiedObject;
        }
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Calling Service Now");
            invocation.Method.Invoke(_proxiedObject, invocation.Arguments);
            //_proxiedObject.Do();
        }

    }

}
