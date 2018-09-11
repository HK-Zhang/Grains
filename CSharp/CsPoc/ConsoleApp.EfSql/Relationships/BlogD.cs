using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class BlogD
    {
        public int BlogDId { get; set; }
        public string Url { get; set; }

        public List<PostD> Posts { get; set; }

    }
}
