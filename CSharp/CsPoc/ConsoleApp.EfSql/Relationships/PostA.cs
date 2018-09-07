using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class PostA
    {
        public int PostAId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public BlogA Blog { get; set; }
    }
}
