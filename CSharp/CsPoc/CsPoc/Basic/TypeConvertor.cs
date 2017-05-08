using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    public class TypeConvertor
    {
        public void Execute()
        {
            Foo1();
        }

        private void Foo1()
        {
            object a = true;
            Console.WriteLine(a.ToString());
        }
    }
}
