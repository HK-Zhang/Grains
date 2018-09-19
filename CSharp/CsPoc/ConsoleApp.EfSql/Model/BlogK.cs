using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogK
    {
        public BlogK(int id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }
        public string Author { get; private set; }

        public ICollection<PostK> Posts { get; } = new List<PostK>();
    }
}
