using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp.EfSql.Model;

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
    }
}
