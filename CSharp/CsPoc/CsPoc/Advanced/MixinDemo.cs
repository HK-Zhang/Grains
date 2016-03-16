using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class MixinDemo
    {
        public void Execute() 
        {
            Foo1();
        }

        private void Foo1() 
        {
            ProxyGenerator generator = new ProxyGenerator();
            var options = new ProxyGenerationOptions();
            options.AddMixinInstance(new ClassA());
            ClassB objB = generator.CreateClassProxy<ClassB>(options, new MyCastleInterceptor());
            objB.ActionB();
            InterfaceA objA = objB as InterfaceA;
            objA.ActionA();

        }
    }

    public interface InterfaceA
    {
        void ActionA();
    }
    public class ClassA : InterfaceA
    {
        public void ActionA()
        {
            Console.WriteLine("I'm from ClassA");
        }
    }
    public class ClassB
    {
        public virtual void ActionB()
        {
            Console.WriteLine("I'm from ClassB");
        }
    }

}
