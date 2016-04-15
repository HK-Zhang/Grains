using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFDemo
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string Content { get; set; }

        //public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public Byte[] TimeStamp { get; set; }

    }
}
