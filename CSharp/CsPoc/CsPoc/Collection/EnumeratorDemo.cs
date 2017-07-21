using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class EnumeratorDemo
    {
        public void Execute()
        {
            var lst = new List<string> {"a","b", "v" };

            using (var a = lst.GetEnumerator())
            {
                a.MoveNext();
                Console.WriteLine(a.Current);
            }


        }
    }
}
