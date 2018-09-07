using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class BlogA
    {
        public int BlogAId { get; set; }
        public string Url { get; set; }

        public List<PostA> Posts { get; set; }
    }
}
