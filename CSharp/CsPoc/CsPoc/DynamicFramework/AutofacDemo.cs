using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using System.Reflection;
using System.Collections;

namespace CsPoc
{
    class AutofacDemo
    {
        public static void BasicRun()
        {
            var build = new ContainerBuilder();
            //build.RegisterType<Class1>();
            build.RegisterType(Type.GetType("CsPoc.Class1"));

            IContainer container = build.Build();
            Class1 class1 = container.Resolve<Class1>();
            class1.foo();


            Class2 class2 = container.ResolveOptional<Class2>();
            if (class2 == null) 
            {
                Console.WriteLine("Class2 is not registered.");
            }

            Class2 class2_0 = null;

            if (container.TryResolve<Class2>(out class2_0))
            {
                class2_0.foo();
            }
            else
            {
                Console.WriteLine("Class2 is not registered.");
            }

        }

        public static void ResolveFoo()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ParameterClass>();

            var container = builder.Build();
            container.Resolve<ParameterClass>(
                new NamedParameter("value", "namedParameter"),      //匹配名字为value的参数
                new TypedParameter(typeof(int), 1),                //匹配类型为int的参数
                new PositionalParameter(4, "positionalParameter"),  //匹配第五个参数（注意，索引位置从0开始）
                new TypedParameter(typeof(int), -1),               //这个将被抛弃，因为前面已经有一个类型为int的TypedParameter
                new ResolvedParameter(
                //第一个Func参数用于返回参数是否符合要求，这里要求参数是类，且命名空间不是System开头，所以第四个参数将会匹配上
                    (pi, cc) => pi.ParameterType.IsClass && !pi.ParameterType.Namespace.StartsWith("System"),
                //第二个Func参数在第一个Func执行结果为true时执行，用于给参数赋值，也就是第四个参数的值为这个Func的执行结果
                    (pi, cc) => new Temp { Name = "resolveParameter" })
                );
            // 最后的输出结果为： {x:1, y:1, value:'namedParameter', temp.Name:'resolveParameter', obj:'positionalParameter'}

        }

        public static void RegisterFoo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly);

            //builder.RegisterAssemblyTypes(assembly).Where(type => type.Namespace.Equals("CsPoc")); //条件判断
            //builder.RegisterAssemblyTypes(assembly).Except<Program>();  //排除Program类型
            //builder.RegisterAssemblyTypes(assembly).InNamespace("CsPoc");  //类型在IocAutofac.Example命名空间中
            //builder.RegisterAssemblyTypes(assembly).InNamespaceOf<Program>();  //类型在Program所在的命名空间中*/
        }

        public static void LambdaFoo()
        {
            var builder = new ContainerBuilder();
            builder.Register(cc => { var class1 = new Class1();
            while (string.IsNullOrEmpty(class1.Id))
            {
                class1.Id = Guid.NewGuid().ToString();
            }
                return class1; });

            IContainer container = builder.Build();
            Class1 class1_0 = container.Resolve<Class1>();
            Console.WriteLine(class1_0.Id);


        }

        public static void RegisterFoo2()
        {
            var class1 = new Class1();
            class1.Id = Guid.NewGuid().ToString();

            var builder = new ContainerBuilder();
            builder.RegisterInstance(class1);

            IContainer container =  builder.Build();
            Class1 c1 = container.Resolve<Class1>();
            Console.WriteLine(c1.Id);
        }

        public static void RegisterFoo3()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ModuleA>();
            builder.RegisterModule(new ModuleB());

            IContainer container = builder.Build();
            Class1 c1 = container.Resolve<Class1>();
            Class2 c2 = container.Resolve<Class2>();

            c1.foo();
            c2.foo();

        }

        public static void IOCFoo()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<ClassA>().PropertiesAutowired();
            builder.RegisterType<ClassB>();

            //builder.RegisterType<ClassC>();
            //builder.RegisterType<ClassA>().PropertiesAutowired();
            builder.RegisterType<ClassA>().WithProperty(new NamedPropertyParameter("c", new ClassC()));
            // builder.RegisterType<ClassA>().WithProperty("B", new ClassB());    //效果与上面相同var container = builder.Build();


            IContainer container = builder.Build();
            ClassA ca = container.Resolve<ClassA>();
            ca.foo();
        }

        public static void IOCLambdaFoo()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => { var a = new ClassA(new ClassB()); a.c = new ClassC(); return a; });

            IContainer container = builder.Build();
            ClassA ca = container.Resolve<ClassA>();
            ca.foo();
        }

        public static void IOCMethodFoo()
        {
            var builder = new ContainerBuilder();
            //builder.Register(cc =>
            //{
            //    var _d = new ClassD();
            //    _d.foo(new ClassB());
            //    return _d;
            //});

            builder.RegisterType<ClassD>().OnActivated(e =>
            {
                e.Instance.foo(new ClassB());
            });

            IContainer container = builder.Build();
            ClassD cd = container.Resolve<ClassD>();

        }

        public static void IterfaceFoo()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CollectionOrderModule());
            //builder.RegisterType<ClassE>().As<IInterface>();
            builder.RegisterType<ClassE>().As<IInterface>().AsSelf();
            builder.RegisterType<ClassF>().AsImplementedInterfaces();


            IContainer container = builder.Build();
            IInterface ii = container.Resolve<IInterface>();
            ClassE ce = container.Resolve<ClassE>();
            Console.WriteLine(ii.Id);
            Console.WriteLine(ce.Id);

            IFace2 if2 = container.Resolve<IFace2>();
            Console.WriteLine(if2.Name);

            IEnumerable<IInterface> lst = container.Resolve<IEnumerable<IInterface>>();
            foreach(IInterface item in lst)
            {
                Console.WriteLine(item.Id);
            }

        }

        public static void EventFoo() 
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterType<A>()  
                .OnRegistered(e =>
                {
                    Console.WriteLine(e);
                });

            builder.Build();    //会触发OnRegistered事件
        }

        public static void EventFoo2()
        {
            var builder = new ContainerBuilder();

            builder.RegisterCallback(cr =>
            {
                // 下面的Registered事件相当类型的OnRegistered事件
                cr.Registered += (sender, eventArgs) =>
                {
                    Console.WriteLine(eventArgs);
                    // OnPreparing事件
                    eventArgs.ComponentRegistration.Preparing += (o, preparingEventArgs) =>
                    {
                        // 1.不做任何处理时，最后输出 result: 3
                        // 2.修改传入值，最后输出 result: 5
                        preparingEventArgs.Parameters = new[] { new NamedParameter("x", 2), new NamedParameter("y", 3) };
                        // 3.修改参数类型，最后输出 id: 7, name: 'undefined'
                        preparingEventArgs.Parameters = new Parameter[] { new PositionalParameter(0, 7), new TypedParameter(typeof(string), "undefined") };
                        // 4.直接不要参数，最后输出 no parameter constructor
                        preparingEventArgs.Parameters = Enumerable.Empty<Parameter>();

                    };
                    // OnActivating事件
                    eventArgs.ComponentRegistration.Activating += (o, activatingEventArgs) =>
                    {

                    };
                    // OnActivated事件
                    eventArgs.ComponentRegistration.Activated += (o, activatedEventArgs) =>
                    {

                    };
                };
            });

            builder.RegisterType<A>();
           IContainer container= builder.Build();
           A a = container.Resolve<A>();
           

        }
    }

    class CollectionOrderModule : IModule
    {

        public void Configure(IComponentRegistry componentRegistry)
        {
            componentRegistry.Registered += (sender, registered) =>
            {
                // only bother watching enumerable resolves
                var limitType = registered.ComponentRegistration.Activator.LimitType;
                if (typeof(IEnumerable).IsAssignableFrom(limitType))
                {
                    registered.ComponentRegistration.Activated += (sender2, activated) =>
                    {
                        // Autofac's IEnumerable feature returns an Array
                        if (activated.Instance is Array)
                        {
                            // Orchard needs FIFO, not FILO, component order
                            Array.Reverse((Array)activated.Instance);
                        }
                    };
                }
            };
        }
    }

    interface IClass
    {
        void foo();
    }

    class Class1:IClass
    {
        public string Id;
        public void foo()
        {
            Console.WriteLine("This is class one");
        }
    }

    class Class2:IClass
    {
        public void foo()
        {
            Console.WriteLine("This is class two");
        }
    }

    class ParameterClass
    {
        public ParameterClass(int x, int y, string value, Temp temp, object obj)
        {
            Console.WriteLine("{{x:{0}, y:{1}, value:'{2}', temp.Name:'{3}', obj:'{4}'}}", x, y, value, temp.Name, obj);
        }
    }

    class Temp
    {
        public string Name { get; set; }
    }

    class ModuleA:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Class1>();
        }
    }

    class ModuleB : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Class2>();
        }
    }

    class ClassA
    {
        public ClassB b { get; set; }
        public ClassC c { get; set; }
        public ClassA(ClassB bp)
        {
            b = bp;
        }

        public void foo()
        {
            b.foo();
            c.foo();
        }

    }

    class ClassD
    {
        public void foo(ClassB b)
        {
            b.foo();
        }
    }

    class ClassB
    {
        public void foo() 
        {
            Console.WriteLine("This is object of ClassB");
        }
        
    }

    class ClassC
    {
        public void foo()
        {
            Console.WriteLine("This is object of Class C");
        }
        
    }

    interface IInterface
    {
        int Id { get;}
    }

    interface IFace2
    {
        int Name { get; }
    }

    class ClassE:IInterface
    {
        private int _id;
        public int Id
        {
            get { return _id; }
        }
    }

    class ClassF:IInterface,IFace2
    {

        public int Id
        {
            get { return 1; }
        }

        public int Name
        {
            get { return 2; }
        }
    }

    class A
    {
        public A()
        {
            Console.WriteLine("no parameter constructor");
        }

        public A(int id, string name)
        {
            Console.WriteLine("id: {0}, name: '{1}'", id, name);
        }

        public A(int x, int y)
        {
            Console.WriteLine("result: {0}", x + y);
        }
    }
}
