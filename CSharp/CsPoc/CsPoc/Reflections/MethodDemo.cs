using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Reflections
{
    public class MethodDemo
    {
        public void Execute()
        {
            declaringTypeFoo();
        }

        private void declaringTypeFoo()
        {
            Console.WriteLine("The declaring type of m is {0}.",typeof(MyClassB).GetMethod("m").DeclaringType);
        }
    }

    public abstract class MyClassA
    {
        public abstract int m();
    }

    public abstract class MyClassB : MyClassA
    {
    }

}
