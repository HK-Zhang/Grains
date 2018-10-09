using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.QueryModel
{
    public class BlogV
    {
        private string _tenantId;

        public int BlogVId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<PostV> Posts { get; set; }
    }

    public class PostV
    {
        public int PostVId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }

        public int BlogVId { get; set; }
        public BlogV Blog { get; set; }
    }
}
