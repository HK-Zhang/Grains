using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    }
}
