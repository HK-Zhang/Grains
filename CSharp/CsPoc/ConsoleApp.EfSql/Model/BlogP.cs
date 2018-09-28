using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogP
    {
        public int BlogPId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
    }
}
