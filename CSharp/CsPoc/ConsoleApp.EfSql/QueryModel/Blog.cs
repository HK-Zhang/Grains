using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.QueryModel
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public Ren Owner { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public List<PTag> Tags { get; set; }
        public Ren Author { get; set; }
    }

    public class Ren
    {
        public int RenId { get; set; }
        public Picture Photo { get; set; }
    }

    public class Picture
    {
        public int PictureId { get; set; }
        public string Content { get; set; }
    }

    public class PTag
    {
        public int PTagId { get; set; }
        public string Name { get; set; }
    }
}
