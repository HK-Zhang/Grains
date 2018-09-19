using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class PostK
    {
        public PostK(int id, string title, DateTime postedOn)
        {
            Id = id;
            Title = title;
            PostedOn = postedOn;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; private set; }

        public BlogK Blog { get; set; }
    }
}
