using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.FP
{
    class FPdemo
    {

        public void Execute()
        {
            var obj = new FPdemoClass();
            obj.id = "abc";

            foo1(() => obj.id);
        }
        private void foo1(Func<string> getFunc)
        {
            Console.WriteLine(getFunc());
        }
    }

    class FPdemoClass
    {
        public string id { get; set; }
    }
}
