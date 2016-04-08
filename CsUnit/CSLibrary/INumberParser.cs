using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveTDD
{
    public interface INumberParser
    {
        int[] Parse(string expression);
    }
    public interface INumberParserFactory
    {
        INumberParser Create(char delimiter);
    }
}
