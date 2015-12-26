using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class RefectionTestObject:IRefection
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    interface IRefection
    {
        int Add(int a, int b);
        
    }
}
