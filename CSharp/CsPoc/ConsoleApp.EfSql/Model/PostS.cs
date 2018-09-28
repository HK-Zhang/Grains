using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class PostS
    {
        public int PostSId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogSId { get; set; }
        public BlogS Blog { get; set; }
    }
}
