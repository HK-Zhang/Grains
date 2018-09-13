using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class PostTag
    {
        public int PostFId { get; set; }
        public PostF Post { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
