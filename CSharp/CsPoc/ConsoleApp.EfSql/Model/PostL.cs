using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class PostL
    {
        private int _id;

        public PostL(string title, DateTime postedOn)
        {
            Title = title;
            PostedOn = postedOn;
        }

        public string Title { get; }
        public string Content { get; set; }
        public DateTime PostedOn { get; }

        public BlogL Blog { get; set; }
    }
}
