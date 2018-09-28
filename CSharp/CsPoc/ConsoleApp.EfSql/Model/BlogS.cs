using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogS
    {
        public int BlogSId { get; set; }
        public string Url { get; set; }

        public List<PostS> Posts { get; set; }
    }
}
