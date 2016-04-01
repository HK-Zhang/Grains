using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class ReadonlyCollectionDemo
    {
        public void Execute()
        {
            //FooReadOnlyList();
            FooIMutableList();

            //FooReadonlyListflaw();
        }

        private void FooReadOnlyList()
        {
            IReadOnlyList<string> lst = new List<string> {"a","b","c" };
            lst.ToList().ForEach((s) => Console.WriteLine(s));
            lst = new List<string> { "d", "b", "c" };
            lst.ToList().ForEach((s) => Console.WriteLine(s));
        }

        private void FooReadonlyListflaw()
        {
            List<string> lst2 = new List<string> { "a", "b", "c", "d" };
            IReadOnlyList<string> lst = lst2;
            lst.ToList().ForEach((s) => Console.WriteLine(s));

            lst2.Add("e");
            lst.ToList().ForEach((s) => Console.WriteLine(s));
        }

        private void FooIMutableList()
        {
            var color1 = ImmutableList.Create("orange", "red", "blue");
            color1.ForEach((s) => Console.WriteLine(s));

             List<string> lst2 = new List<string> { "a", "b", "c", "d" };
             var lst = lst2.ToImmutableList();
             lst.ForEach((s) => Console.WriteLine(s));

             lst2.Add("e");
             lst.ForEach((s) => Console.WriteLine(s));



        }
    }
}
