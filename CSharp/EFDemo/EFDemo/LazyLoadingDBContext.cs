using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class LazyLoadingDBContext:SchoolEFContext
    {
        public LazyLoadingDBContext()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
    }
}
