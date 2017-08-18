using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class CollectionOptsDemo
    {
        public string[] ConcactArray(string[] source, string[] target)
        {
            return source.Concat(target).ToArray();
        }
    }
}
