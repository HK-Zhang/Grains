using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class PostM
    {
        public int PostMId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogMId { get; set; }

    }
}
