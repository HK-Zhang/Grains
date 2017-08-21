using StdTwoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.STD
{
    public class ConfigDemo
    {
        public void Execute()
        {
            var r = new ConfigReader();
            r.ReadConfig();
        }
    }
}
