using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    interface InheritanceDemo
    {
        void Mytype();
    }

    public abstract class AbstractIneritanceDemo : InheritanceDemo
    {
        public void Mytype()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    public class MyIneritanceDemo : AbstractIneritanceDemo
    {
        
    }

    public class BasicInheritanceDemo
    {
        public void Execute()
        {
            InheritanceDemo a = new MyIneritanceDemo();
            a.Mytype();
        }
    }


}
