using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class TypeDescriptorDemo
    {
        public void Execute()
        {
            //Foo();
            //Foo1();
            Foo2();
        }

        private void Foo()
        {
            Console.WriteLine(Attribute.GetCustomAttributes(typeof(Class2), typeof(Attribute1)).Count());
            Console.WriteLine(TypeDescriptor.GetAttributes(typeof(Class2)).Count);
        }

        private void Foo1()
        {
            Console.WriteLine(Attribute.GetCustomAttributes(typeof(Class1), typeof(Attribute2)).Count());
            Console.WriteLine(TypeDescriptor.GetAttributes(typeof(Class1)).Count);
        }

        private void Foo2()
        {
            Console.WriteLine(Attribute.GetCustomAttributes(typeof(Class3), typeof(Attribute1)).Count());
            Console.WriteLine(TypeDescriptor.GetAttributes(typeof(Class3)).Count);
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Attribute1 : Attribute
    {
        public string Name { get; set; }
        public override object TypeId
        {
            get
            {
                return this;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Attribute2 : Attribute
    {
        public string Name { get; set; }
    }

    [Attribute1(Name = "a1")]
    [Attribute1(Name = "a2")]
    public class Class2
    {

    }

    [Attribute2(Name = "a1")]
    [Attribute2(Name = "a2")]
    public class Class1
    {

    }

    [Attribute1(Name = "a1")]
    [Attribute1(Name = "a1")]
    public class Class3
    {

    }
}
