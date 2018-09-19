using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogJ
    {
        public BlogJ(int id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }

        public ICollection<PostJ> Posts { get; } = new List<PostJ>();
    }
}
