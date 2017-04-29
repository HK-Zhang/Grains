using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    class EqualsDemo
    {
        public static void Execute()
        {
            ClassEqual ce = new ClassEqual();
            ClassEqual ce2 = new ClassEqual();

            Console.WriteLine(ce.Equals(ce2));
            Console.WriteLine(ce==ce2);
        }
    }

    public class ClassEqual
    {
        public override int GetHashCode()
        {
            return 1;
        }

        public override bool Equals(object obj)
        {
            return true;
        }

    }
}
