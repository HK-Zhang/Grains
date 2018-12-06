using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.FP
{
    public class ActionDemo
    {
        static Action<container> _counter;

        public static void Execute()
        {
            _counter = (c) => c.i = 1;
            _counter += (c) => c.i++;

            var c1 = new container();
            _counter.Invoke(c1);

            Console.WriteLine(c1.i);
        }

        class container
        {
            public int i;
        }
    }
}
