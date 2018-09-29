using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogT
    {
        public int BlogTId { get; set; }
        public string Url { get; set; }

    }

    public class RssBlogT : BlogT
    {
        public string RssUrl { get; set; }
    }
}
