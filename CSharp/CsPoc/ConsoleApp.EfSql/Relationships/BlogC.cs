using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class BlogC
    {
        public int BlogCId { get; set; }
        public string Url { get; set; }

        public List<PostC> Posts { get; set; }
    }
}
