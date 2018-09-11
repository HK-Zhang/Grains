using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class PostD
    {
        public int PostDId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public BlogD Blog { get; set; }
    }
}
