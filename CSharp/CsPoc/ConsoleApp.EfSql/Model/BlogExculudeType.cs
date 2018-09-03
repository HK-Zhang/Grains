using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogExculudeType
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public BlogMetadata Metadata { get; set; }
    }

    public class BlogMetadata
    {
        public DateTime LoadedFromDatabase { get; set; }
    }
}
