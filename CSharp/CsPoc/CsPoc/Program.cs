using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicDemo dd = new DynamicDemo();
            //dd.VsObject();
            //dd.PropertyDemo();
            //dd.ReflectionDemo();
            //dd.ExpandoObjectDemo();
            //dd.DynamicProductDemo();
            ReflectionDemo.Execute();
            Console.ReadLine();
        }
    }
}
