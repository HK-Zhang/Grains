using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class BlogB
    {
        public int BlogBId { get; set; }
        public string Url { get; set; }

        public List<PostB> Posts { get; set; }
    }
}
