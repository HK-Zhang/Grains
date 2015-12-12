using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class ReflectionDemo
    {
        public delegate int AddMethod(int a,int b);
        private const int _TIMES = 100000;

        private static double _Run(string description,Action<int,int> action,int a,int b) 
        {
            if (action == null) throw new ArgumentNullException("action");
            var stopWatch = Stopwatch.StartNew();
            action(a, b);
            stopWatch.Stop();
            Console.WriteLine("{0}:{1}", description, stopWatch.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
            return stopWatch.Elapsed.TotalMilliseconds;
        }

        private static void _Method1(int a, int b)
        {
            var obj = new RefectionTestObject();
            for (int i = 0; i < _TIMES; ++i)
            {
                obj.Add(a, b);
            }

        }

        private static void _Method2(int a, int b)
        {
            var obj = new RefectionTestObject();
            var add = obj.GetType().GetMethod("Add");
            for (int i = 0; i < _TIMES; ++i) 
            {
                add.Invoke(obj, new object[] { a, b });
            }
        }

        private static void _Method3(int a, int b) 
        {
            dynamic obj = new RefectionTestObject();
            for (int i = 0; i < _TIMES; ++i)
            {
                obj.Add(a, b);
            }

        }

        private static void _Method4(int a, int b) 
        {
            var obj = new RefectionTestObject();
            var add = obj.GetType().GetMethod("Add");
            var d = (Func<RefectionTestObject, int, int, int>)Delegate.CreateDelegate(typeof(Func<RefectionTestObject, int, int, int>), add);

            for (var i = 0; i < _TIMES; i++) d(obj, a, b);
        }

        private static void _Method5(int a, int b)
        {
            var obj = new RefectionTestObject();
            var add = obj.GetType().GetMethod("Add");
            var d = (AddMethod)Delegate.CreateDelegate(typeof(AddMethod), obj, add);
            for (var i = 0; i < _TIMES; i++) d(a, b);
        }

        public static void Execute() 
        {
            var results = new double[5];

            const int count = 20;

            for (var i = 0; i < count; i++)
            {
                results[0] += _Run("Generic Call", _Method1, 2, 3);
                results[1] += _Run("  Reflection", _Method2, 2, 3);
                results[2] += _Run("     dynamic", _Method3, 2, 3);
                results[3] += _Run("        Func", _Method4, 2, 3);
                results[4] += _Run("    Delegate", _Method5, 2, 3);

                Console.WriteLine();
            }

            Console.WriteLine("平均：");

            for (var i = 0; i < results.Length; i++)
            {
                results[i] = results[i] / count;

                Console.WriteLine(results[i]);
            }



        }

    }
}
