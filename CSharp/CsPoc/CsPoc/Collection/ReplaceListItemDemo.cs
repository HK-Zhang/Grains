using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class ReplaceListItemDemo
    {
        public static void Execute()
        {
            var lst = new List<ReplaceListItemDemoC>();
            lst.Add(new ReplaceListItemDemoC(){ name ="a", value="a_1" });
            lst.Add(new ReplaceListItemDemoC() { name = "b", value = "b_1" });


            var a = lst.FirstOrDefault(t => t.name == "a");
            var c = new ReplaceListItemDemoC() {name = "c", value = "c_1"};

            lst.Insert(lst.IndexOf(a), c);
            lst.RemoveAt(lst.IndexOf(a));

            lst.ForEach(t => { Console.WriteLine(t.value); });

        }
    }

    public class ReplaceListItemDemoC
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
