using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogExcludeProperty
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public DateTime LoadedFromDatabase { get; set; }
    }
}
