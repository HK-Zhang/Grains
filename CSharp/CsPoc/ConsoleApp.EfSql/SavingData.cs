using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp.EfSql.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.EfSql
{
    public class SavingData
    {

        public void BasicSaveAdd()
        {
            using (var context = new BloggingContext())
            {
                var blog = new BlogF { Url = "http://sample.com" };
                context.BlogFs.Add(blog);
                context.SaveChanges();

                Console.WriteLine(blog.BlogFId + ": " + blog.Url);
            }
        }

        public void BasicSaveUpdate()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.BlogFs.First();
                blog.Url = "http://sample.com/blog";
                context.SaveChanges();


                Console.WriteLine(blog.BlogFId + ": " + blog.Url);
            }
        }

        public void BasicSaveDelete()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.BlogFs.First();
                context.BlogFs.Remove(blog);
                context.SaveChanges();

            }
        }

        public void BasicSaveMultiOps()
        {
            using (var context = new BloggingContext())
            {
                // add
                context.BlogFs.Add(new BlogF { Url = "http://sample.com/blog_one" });
                context.BlogFs.Add(new BlogF { Url = "http://sample.com/blog_two" });

                // update
                var firstBlog = context.BlogFs.First();
                firstBlog.Url = "";

                // remove
                var lastBlog = context.BlogFs.Last();
                context.BlogFs.Remove(lastBlog);

                context.SaveChanges();
            }
        }

        public void RelatedData()
        {
            using (var context = new BloggingContext())
            {
                var blog = new Blog
                {
                    Url = "http://blogs.msdn.com/dotnet",
                    Posts = new List<Post>
                    {
                        new Post { Title = "Intro to C#" },
                        new Post { Title = "Intro to VB.NET" },
                        new Post { Title = "Intro to F#" }
                    }
                };

                context.Blogs.Add(blog);
                context.SaveChanges();
            }
        }

        public void RelatedDataAddRelatedEntity()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Include(b => b.Posts).First();
                var post = new Post { Title = "Intro to EF Core" };

                blog.Posts.Add(post);
                context.SaveChanges();
            }
        }

        public void RealtedDataRelationships()
        {
            using (var context = new BloggingContext())
            {
                var blog = new Blog { Url = "http://blogs.msdn.com/visualstudio" };
                var post = context.Posts.First();

                post.Blog = blog;
                context.SaveChanges();
            }
        }

        public void RelatedDataRemoveRelationship()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Include(b => b.Posts).First();
                var post = blog.Posts.First();

                blog.Posts.Remove(post);
                context.SaveChanges();
            }
        }

        public void CascadeDelete()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Include(b => b.Posts).First();
                var posts = blog.Posts.ToList();

//                DumpEntities("  After loading entities:", context, blog, posts);

                context.Remove(blog);

//                DumpEntities($"  After deleting blog '{blog.BlogId}':", context, blog, posts);

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("  Saving changes:");

                    context.SaveChanges();

//                    DumpSql();
//
//                    DumpEntities("  After SaveChanges:", context, blog, posts);
                }
                catch (Exception e)
                {
//                    DumpSql();

                    Console.WriteLine();
                    Console.WriteLine($"  SaveChanges threw {e.GetType().Name}: {(e is DbUpdateException ? e.InnerException.Message : e.Message)}");
                }
            }
        }

        public void DeleteOrphansExample()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Include(b => b.Posts).First();
                var posts = blog.Posts.ToList();

//                DumpEntities("  After loading entities:", context, blog, posts);

                blog.Posts.Clear();

//                DumpEntities("  After making posts orphans:", context, blog, posts);

                try
                {
                    Console.WriteLine();
                    Console.WriteLine("  Saving changes:");

                    context.SaveChanges();

//                    DumpSql();

//                    DumpEntities("  After SaveChanges:", context, blog, posts);
                }
                catch (Exception e)
                {
//                    DumpSql();

                    Console.WriteLine();
                    Console.WriteLine($"  SaveChanges threw {e.GetType().Name}: {(e is DbUpdateException ? e.InnerException.Message : e.Message)}");
                }
            }
        }
    }
}
