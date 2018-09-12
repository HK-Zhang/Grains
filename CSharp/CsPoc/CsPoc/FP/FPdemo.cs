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

            foo2().Wait();

//            var obj = new FPdemoClass();
//            obj.id = "abc";
//
//            foo1(() => obj.id);
        }
        private void foo1(Func<string> getFunc)
        {
            Console.WriteLine(getFunc());
        }

        private async Task foo2()
        {
            Func<string,Task<int>> function = p => Task.FromResult(1);

            Func<string, Task<int>> awaitfunction = async p => await Task.FromResult(2);

            Console.WriteLine(function.Invoke("2").Result);

            Console.WriteLine(awaitfunction.Invoke("2").Result);

            var a = await function.Invoke("2");
            var b = await awaitfunction.Invoke("2");

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }

    class FPdemoClass
    {
        public string id { get; set; }
    }
}
