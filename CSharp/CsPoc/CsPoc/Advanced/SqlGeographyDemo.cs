using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;

namespace CsPoc.Advanced
{
    class SqlGeographyDemo
    {
        public static void Execute()
        {
            var a = SqlGeography.Point(31.8300167, 35.0662833, 4326);
            var b = SqlGeography.Point(31.8300000, 35.0708167, 4326);
            var d = Math.Round((double)a.STDistance(b), 2);

            Console.WriteLine(d);
        }
    }
}
