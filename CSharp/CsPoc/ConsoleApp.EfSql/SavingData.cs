using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ConsoleApp.EfSql.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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

        public void ConcurrencyConflicts()
        {
            using (var context = new BloggingContext())
            {
                // Fetch a person from database and change phone number
                var person = context.People.Single(p => p.PersonId == 1);
                person.LastName = "555-555-5555";

                // Change the person's name in the database to simulate a concurrency conflict
                context.Database.ExecuteSqlCommand(
                    "UPDATE dbo.People SET FirstName = 'Jane' WHERE PersonId = 1");

                var saved = false;
                while (!saved)
                {
                    try
                    {
                        // Attempt to save changes to the database
                        context.SaveChanges();
                        saved = true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        foreach (var entry in ex.Entries)
                        {
                            if (entry.Entity is Person)
                            {
                                var proposedValues = entry.CurrentValues;
                                var databaseValues = entry.GetDatabaseValues();

                                foreach (var property in proposedValues.Properties)
                                {
                                    var proposedValue = proposedValues[property];
                                    var databaseValue = databaseValues[property];

                                    // TODO: decide which value should be written to database
                                    // proposedValues[property] = <value to be saved>;
                                }

                                // Refresh original values to bypass next concurrency check
                                entry.OriginalValues.SetValues(databaseValues);
                            }
                            else
                            {
                                throw new NotSupportedException(
                                    "Don't know how to handle concurrency conflicts for "
                                    + entry.Metadata.Name);
                            }
                        }
                    }
                }
            }
        }

        public void ControlTransactions()
        {
            using (var context = new BloggingContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                        context.SaveChanges();

                        context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/visualstudio" });
                        context.SaveChanges();

                        var blogs = context.Blogs
                            .OrderBy(b => b.Url)
                            .ToList();

                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // TODO: Handle failure
                    }
                }
            }
        }

        public void CrossContextTransaction()
        {

            using (var conn =
                new SqlConnection(
                    "Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true")
            )
            {
                using (var context1 = new BloggingContext(conn))
                {
                    using (var transaction = context1.Database.BeginTransaction())
                    {
                        try
                        {
                            context1.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                            context1.SaveChanges();

                            using (var context2 = new BloggingContext(conn))
                            {
                                context2.Database.UseTransaction(transaction.GetDbTransaction());

                                var blogs = context2.Blogs
                                    .OrderBy(b => b.Url)
                                    .ToList();
                            }

                            // Commit transaction if all commands succeed, transaction will auto-rollback
                            // when disposed if either commands fails
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            // TODO: Handle failure
                        }
                    }
                }
            }


        }

        public void UseExternalTransaction()
        {
            using (var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Run raw ADO.NET command in the transaction
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandText = "DELETE FROM dbo.Blogs";
                        command.ExecuteNonQuery();

                        using (var context = new BloggingContext(connection))
                        {
                            context.Database.UseTransaction(transaction);
                            context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                            context.SaveChanges();
                        }

                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        transaction.Commit();
                    }
                    catch (System.Exception)
                    {
                        // TODO: Handle failure
                    }
                }
            }
        }

        public void SystemTransaction()
        {
            using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                using (var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    try
                    {
                        // Run raw ADO.NET command in the transaction
                        var command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM dbo.Blogs";
                        command.ExecuteNonQuery();

                        using (var context = new BloggingContext(connection))
                        {
                            context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                            context.SaveChanges();
                        }

                        // Commit transaction if all commands succeed, transaction will auto-rollback
                        // when disposed if either commands fails
                        scope.Complete();
                    }
                    catch (System.Exception)
                    {
                        // TODO: Handle failure
                    }
                }
            }
        }

        public void EnlistTransaction()
        {
            using (var transaction = new CommittableTransaction(
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true");

                try
                {

                    using (var context = new BloggingContext(connection))
                    {
                        context.Database.OpenConnection();
                        context.Database.EnlistTransaction(transaction);

                        // Run raw ADO.NET command in the transaction
                        var command = connection.CreateCommand();
                        command.CommandText = "DELETE FROM dbo.Blogs";
                        command.ExecuteNonQuery();

                        // Run an EF Core command in the transaction
                        context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                        context.SaveChanges();
                        context.Database.CloseConnection();
                    }

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    // TODO: Handle failure
                }
            }
        }

        public static async Task AddBlogAsync(string url)
        {
            using (var context = new BloggingContext())
            {
                var blog = new Blog { Url = url };
                context.Blogs.Add(blog);
                await context.SaveChangesAsync();
            }
        }

        public static bool IsItNew(Blog blog)
            => blog.BlogId == 0;

        public static bool IsItNew(DbContext context, object entity)
            => !context.Entry(entity).IsKeySet;

        public static bool IsItNew(BloggingContext context, Blog blog)
            => context.Blogs.Find(blog.BlogId) == null;

        public static void Insert(DbContext context, object entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public static void Update(DbContext context, object entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        // if the entity uses auto-generated key values, then the Update method can be used for both cases
        public static void InsertOrUpdate(DbContext context, object entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        // If the entity is not using auto-generated keys, then the application must decide whether the entity should be inserted or updated
        public static void InsertOrUpdate(BloggingContext context, Blog blog)
        {
            var existingBlog = context.Blogs.Find(blog.BlogId);
            if (existingBlog == null)
            {
                context.Add(blog);
            }
            else
            {
                context.Entry(existingBlog).CurrentValues.SetValues(blog);
            }

            context.SaveChanges();
        }

        public static void InsertGraph(DbContext context, object rootEntity)
        {
            context.Add(rootEntity);
            context.SaveChanges();
        }

        public static void UpdateGraph(DbContext context, object rootEntity)
        {
            context.Update(rootEntity);
            context.SaveChanges();
        }

        // With auto-generated keys, Update can again be used for both inserts and updates, even if the graph contains a mix of entities that require inserting and those that require updating
        public static void InsertOrUpdateGraph(DbContext context, object rootEntity)
        {
            context.Update(rootEntity);
            context.SaveChanges();
        }

        // when not using auto-generated keys, a query and some processing can be used
        public static void InsertOrUpdateGraph(BloggingContext context, Blog blog)
        {
            var existingBlog = context.Blogs
                .Include(b => b.Posts)
                .FirstOrDefault(b => b.BlogId == blog.BlogId);

            if (existingBlog == null)
            {
                context.Add(blog);
            }
            else
            {
                context.Entry(existingBlog).CurrentValues.SetValues(blog);
                foreach (var post in blog.Posts)
                {
                    var existingPost = existingBlog.Posts
                        .FirstOrDefault(p => p.PostId == post.PostId);

                    if (existingPost == null)
                    {
                        existingBlog.Posts.Add(post);
                    }
                    else
                    {
                        context.Entry(existingPost).CurrentValues.SetValues(post);
                    }
                }
            }

            context.SaveChanges();
        }

        // For true deletes, a common pattern is to use an extension of the query pattern to perform what is essentially a graph diff
        public static void InsertUpdateOrDeleteGraph(BloggingContext context, Blog blog)
        {
            var existingBlog = context.Blogs
                .Include(b => b.Posts)
                .FirstOrDefault(b => b.BlogId == blog.BlogId);

            if (existingBlog == null)
            {
                context.Add(blog);
            }
            else
            {
                context.Entry(existingBlog).CurrentValues.SetValues(blog);
                foreach (var post in blog.Posts)
                {
                    var existingPost = existingBlog.Posts
                        .FirstOrDefault(p => p.PostId == post.PostId);

                    if (existingPost == null)
                    {
                        existingBlog.Posts.Add(post);
                    }
                    else
                    {
                        context.Entry(existingPost).CurrentValues.SetValues(post);
                    }
                }

                foreach (var post in existingBlog.Posts)
                {
                    if (blog.Posts.All(p => p.PostId != post.PostId))
                    {
                        context.Remove(post);
                    }
                }
            }

            context.SaveChanges();
        }

        public static void SaveAnnotatedGraph(DbContext context, object rootEntity)
        {
            context.ChangeTracker.TrackGraph(
                rootEntity,
                n =>
                {
                    var entity = (EntityBase)n.Entry.Entity;
                    n.Entry.State = entity.IsNew
                        ? EntityState.Added
                        : entity.IsChanged
                            ? EntityState.Modified
                            : entity.IsDeleted
                                ? EntityState.Deleted
                                : EntityState.Unchanged;
                });

            context.SaveChanges();
        }
    }

    internal class EntityBase
    {
        public bool IsNew { get; set; }
        public bool IsChanged { get; internal set; }
        public bool IsDeleted { get; internal set; }
    }
}
