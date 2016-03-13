using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    public class TypeListDemo
    {
        public void Execute()
        {
            //Foo1();
            Foo3();
        }

        public void Foo1()
        {
            IList<TypeParent> lt = new List<TypeParent>();
            lt.Add(new TypeParent { strP = "parent" });
            lt.Add(new TypeChild { strP = "child" });
            lt.ToList().ForEach((t) => { Console.WriteLine(t.strP); });

        }

        public void Foo2()
        {
            IList<TypeChild> lt = new List<TypeChild>();
            //lt.Add(new TypeParent { strP = "parent" });
            lt.Add(new TypeChild { strP = "child" });
            lt.ToList().ForEach((t) => { Console.WriteLine(t.strP); });
        }

        public void Foo3()
        {
            ITypeList<TypeParent> lt = new TypeList<TypeParent>();
            lt.Add<TypeParent>();
            lt.Add(typeof(TypeChild));
            lt.Add(typeof(int));
            //lt.Add(new TypeParent { strP = "parent" });
            //lt.Add(new TypeChild { strP = "child" });
            lt.ToList().ForEach((t) => { Console.WriteLine(t.ToString()); });
        }

    }

    public class TypeParent
    {
        public string strP { get; set;}
    }

    public class TypeChild : TypeParent 
    {
        public string strC { get; set; }
    }
}
