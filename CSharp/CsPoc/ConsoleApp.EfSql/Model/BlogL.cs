using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogL
    {
        private int _id;

        public BlogL(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public string Name { get; }
        public string Author { get; }

        public ICollection<PostL> Posts { get; } = new List<PostL>();
    }
}
