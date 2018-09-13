using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class BlogE
    {
        public int BlogEId { get; set; }
        public string Url { get; set; }

        public BlogImage BlogImage { get; set; }
    }
}
