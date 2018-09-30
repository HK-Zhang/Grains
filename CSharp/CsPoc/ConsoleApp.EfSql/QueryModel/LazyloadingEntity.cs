using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.QueryModel
{
    public class LZBlog
    {
        private ICollection<LZPost> _posts;

        public LZBlog()
        {
        }

        private LZBlog(Action<object, string> lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private Action<object, string> LazyLoader { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<LZPost> Posts
        {
            get => LazyLoader.Load(this, ref _posts);
            set => _posts = value;
        }
    }

    public class LZPost
    {
        private LZBlog _blog;

        public LZPost()
        {
        }

        private LZPost(Action<object, string> lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private Action<object, string> LazyLoader { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public LZBlog Blog
        {
            get => LazyLoader.Load(this, ref _blog);
            set => _blog = value;
        }
    }
}
