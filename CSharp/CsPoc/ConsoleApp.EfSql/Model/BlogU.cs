using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogU
    {
        public int BlogUId { get; set; }
        public string Url { get; set; }
        public string BlogType { get; set; }
    }

    public class RssBlogU : BlogU
    {
        public string RssUrl { get; set; }
    }
}
