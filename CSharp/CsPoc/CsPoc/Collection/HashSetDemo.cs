using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class HashSetDemo
    {
        public void Execute()
        {
            HashSet<Product> set = new HashSet<Product>(new Compare());



            set.Add(new Product { ID = 1 });
            set.Add(new Product { ID = 1 });
            set.Add(new Product { ID = 2 });

            Console.WriteLine(set.ToList().Count);
        }
    }

    class Compare : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x.ID == y.ID;
        }
        public int GetHashCode(Product codeh)
        {
            return codeh.ID.GetHashCode();
        }
    }
}
