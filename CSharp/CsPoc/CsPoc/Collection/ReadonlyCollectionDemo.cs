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
            //            FooIMutableList();
            ChanageInterlItem();
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

        private void ChanageInterlItem()
        {
            List<Book> lst2 = new List<Book> {new Book{id = "1",title="a" }, new Book { id = "2", title = "b" } };
            IReadOnlyList<Book> lst = lst2;
            lst.ToList().ForEach((s) => Console.WriteLine(s.title));
            lst[0].title = "c";
            lst.ToList().ForEach((s) => Console.WriteLine(s.title));

            var lst3 = ImmutableList.Create(new Book { id = "1", title = "a" }, new Book { id = "2", title = "b" });
            lst3.ForEach((s) => Console.WriteLine(s.title));

            lst3[0].title = "c";
            lst3.ToList().ForEach((s) => Console.WriteLine(s.title));

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

    public class Book
    {
        public string id { get; set; }
        public string title { get; set; }
    }
}
