using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class PostJ
    {
        public PostJ(int id, string title, DateTime postedOn)
        {
            Id = id;
            Title = title;
            PostedOn = postedOn;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }

        public BlogJ Blog { get; set; }

    }
}
