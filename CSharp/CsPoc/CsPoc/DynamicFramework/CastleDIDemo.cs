using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace CsPoc.DynamicFramework
{
    public class CastleDIDemo
    {
        public void Execute()
        {
            Foo();
            //Foo1();
        }

        public void Foo() 
        {
            var container = new WindsorContainer();

            container.Register(
                Component.For<IEventBus>().UsingFactoryMethod(() => { return new EventBus(); }).LifestyleSingleton()
                );

            IEventBus eventBus = container.Resolve<IEventBus>();
            eventBus.Foo();
        }

        public void Foo1()
        {
            var container = new WindsorContainer();

            container.Register(
                 Component.For<IBus>().ImplementedBy<Bus>().LifestyleTransient(),
                Component.For<IEventBus>().ImplementedBy<EventBus>().LifestyleSingleton()
                );

            IEventBus eventBus = container.Resolve<IEventBus>();
            eventBus.Foo();
        }
    }

    public interface IEventBus
    {
        void Foo();
    }

    public interface IBus
    {
        int BusNum { get; set; }
    }

    public class Bus:IBus
    {
        public Bus()
        {
            BusNum = 1;
        }

        public int BusNum { get; set; }
    }

    public class EventBus:IEventBus
    {
        public IBus bus { get; set; }
        public EventBus()
        { 
        }

        public void Foo()
        {
            Console.WriteLine(bus.BusNum);
        }
    }
}
