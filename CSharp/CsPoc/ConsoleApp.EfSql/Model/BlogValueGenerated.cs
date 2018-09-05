using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogValueGenerated
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool Inserted { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
