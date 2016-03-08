using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    public sealed class Singleton
    {
        static readonly Singleton singleton = new Singleton();

        Singleton()
        { 
        }

        static Singleton()
        { 
        }

        public static Singleton instance 
        {
            get 
            {
                return singleton;
            }
        }
    }


}
