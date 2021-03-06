﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.EfSql.QueryModel;
using Microsoft.EntityFrameworkCore;
using Blog = ConsoleApp.EfSql.Model.Blog;

namespace ConsoleApp.EfSql
{
    public class QueryingData
    {
        public static void BasicQuery()
        {
            using (var context = new BloggingContext())
            {
                var blogs = context.Blogs.ToList();
            }

            using (var context = new BloggingContext())
            {
                var blog = context.Blogs
                    .Single(b => b.BlogId == 1);
            }

            using (var context = new BloggingContext())
            {
                var blogs = context.Blogs
                    .Where(b => b.Url.Contains("dotnet"))
                    .ToList();
            }
        }

        public static void EagerLoading()
        {
            using (var context = new QueryingContext())
            {
                var blogs = context.QBlogs
                    .Include(blog => blog.Posts)
                    .ThenInclude(post => post.Author)
                    .ThenInclude(author => author.Photo)
                    .Include(blog => blog.Owner)
                    .ThenInclude(owner => owner.Photo)
                    .ToList();
            }


            using (var context = new QueryingContext())
            {
                var blogs = context.QBlogs
                    .Include(blog => blog.Posts)
                    .ThenInclude(post => post.Author)
                    .Include(blog => blog.Posts)
                    .ThenInclude(post => post.Tags)
                    .ToList();
            }

            using (var context = new QueryingContext())
            {
                var students = context.RenMen.Include(person => ((Student)person).School).ToList();

                //context.RenMen.Include(person => (person as Student).School).ToList();

                //context.RenMen.Include("Student").ToList();

            }

        }

        public static void ExplictLoading()
        {
            using (var context = new QueryingContext())
            {
                var blog = context.QBlogs
                    .Single(b => b.BlogId == 1);

                context.Entry(blog)
                    .Collection(b => b.Posts)
                    .Load();

                context.Entry(blog)
                    .Reference(b => b.Owner)
                    .Load();
            }

            using (var context = new QueryingContext())
            {
                var blog = context.QBlogs
                    .Single(b => b.BlogId == 1);

                var postCount = context.Entry(blog)
                    .Collection(b => b.Posts)
                    .Query()
                    .Count();
            }

            using (var context = new QueryingContext())
            {
                var blog = context.QBlogs
                    .Single(b => b.BlogId == 1);

                var goodPosts = context.Entry(blog)
                    .Collection(b => b.Posts)
                    .Query()
                    .Where(p => p.PostId > 3)
                    .ToList();
            }
        }

        public static string StandardizeUrl(string url)
        {
            url = url.ToLower();

            if (!url.StartsWith("http://"))
            {
                url = string.Concat("http://", url);
            }

            return url;
        }

        public static void ClientEvaluation()
        {
            using (var context = new QueryingContext())
            {
                var blogs = context.QBlogs
                    .Select(blog => new
                    {
                        Id = blog.BlogId,
                        Url = StandardizeUrl(blog.Url)
                    })
                    .ToList();
            }
        }

        public static void DisableTracking()
        {
            using (var context = new BloggingContext())
            {
                var blogs = context.Blogs
                    .AsNoTracking()
                    .ToList();
            }

            using (var context = new BloggingContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var blogs = context.Blogs.ToList();
            }
        }

        public static void RunRawQuery()
        {
            using (var context = new BloggingContext())
            {
                var blogs = context.Blogs
                    .FromSql("SELECT * FROM dbo.Blogs")
                    .ToList();
            }

            using (var context = new BloggingContext())
            {
                var blogs = context.Blogs
                    .FromSql("EXECUTE dbo.GetMostPopularBlogs")
                    .ToList();
            }

            using (var context = new BloggingContext())
            {
                var user = "johndoe";

                var blogs = context.Blogs
                    .FromSql("EXECUTE dbo.GetMostPopularBlogsForUser {0}", user)
                    .ToList();
            }

            using (var context = new BloggingContext())
            {
                var user = "johndoe";

                var blogs = context.Blogs
                    .FromSql($"EXECUTE dbo.GetMostPopularBlogsForUser {user}")
                    .ToList();
            }

            using (var context = new BloggingContext())
            {
                var user = new SqlParameter("user", "johndoe");

                var blogs = context.Blogs
                    .FromSql("EXECUTE dbo.GetMostPopularBlogsForUser @user", user)
                    .ToList();
            }
        }

        public async Task<List<Blog>> GetBlogsAsync()
        {
            using (var context = new BloggingContext())
            {
                return await context.Blogs.ToListAsync();
            }
        }

    }
}
