using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogTimestamp
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
