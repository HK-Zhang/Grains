using System;
using System.Linq;
using ConsoleApp.EfSql.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.EfSql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello EntityFramework Core!");

            var democase = "ExplictValueOnUpdate";

            switch (democase)
            {
                case "SimpleSample":
                    SimpleSample();
                    break;
                case "ExecludeTypesSample":
                    ExecludeTypesSample();
                    break;
                case "ExecludePropertySample":
                    ExecludePropertySample();
                    break;
                case "ExplictValueOnAdd":
                    ExplictValueOnAdd();
                    break;
                case "ExplictIdentity":
                    ExplictIdentity();
                    break;
                case "ExplictValueOnUpdate":
                    ExplictValueOnUpdate();
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }

        static void SimpleSample()
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }

        static void ExecludeTypesSample()
        {
            using (var db = new BloggingContext())
            {
                db.BlogExculudeTypes.Add(new BlogExculudeType { Url = "http://blogs.msdn.com/adonet", Metadata = new BlogMetadata { LoadedFromDatabase = DateTime.Now } });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.BlogExculudeTypes)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }

        static void ExecludePropertySample()
        {
            using (var db = new BloggingContext())
            {
                db.BlogExcludePropertys.Add(new BlogExcludeProperty { Url = "http://blogs.msdn.com/adonet", LoadedFromDatabase = DateTime.Now });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.BlogExcludePropertys)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }

        static void ExplictValueOnAdd()
        {
            using (var context = new EmployeeContext())
            {
                context.Employees.Add(new Employee { Name = "John Doe" });
                context.Employees.Add(new Employee { Name = "Jane Doe", EmploymentStarted = new DateTime(2000, 1, 1) });
                context.SaveChanges();

                foreach (var employee in context.Employees)
                {
                    Console.WriteLine(employee.EmployeeId + ": " + employee.Name + ", " + employee.EmploymentStarted);
                }
            }
        }

        static void ExplictIdentity()
        {
            using (var context = new EmployeeContext())
            {
                context.Employees.Add(new Employee { EmployeeId = 100, Name = "John Doe" });
                context.Employees.Add(new Employee { EmployeeId = 101, Name = "Jane Doe" });

                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Employees ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Employees OFF");
                }
                finally
                {
                    context.Database.CloseConnection();
                }


                foreach (var employee in context.Employees)
                {
                    Console.WriteLine(employee.EmployeeId + ": " + employee.Name);
                }
            }
        }

        static void ExplictValueOnUpdate()
        {
            using (var context = new EmployeeContext())
            {
                context.EmployeeGenreateOnUpdates.Add(new EmployeeGenreateOnUpdate { Name = "John Doe" });
                context.EmployeeGenreateOnUpdates.Add(new EmployeeGenreateOnUpdate { Name = "Jane Doe", EmploymentStarted = new DateTime(2000, 1, 1) });
                context.SaveChanges();

                foreach (var employee in context.EmployeeGenreateOnUpdates)
                {
                    Console.WriteLine(employee.Id + ": " + employee.Name + ", " + employee.EmploymentStarted);
                }
            }

            using (var context = new EmployeeContext())
            {
                var john = context.EmployeeGenreateOnUpdates.Single(e => e.Name == "John Doe");
                john.Salary = 300;

                var jane = context.EmployeeGenreateOnUpdates.Single(e => e.Name == "Jane Doe");
                jane.Salary = 300;
                jane.LastPayRaise = DateTime.Today.AddDays(-7);

                context.SaveChanges();

                foreach (var employee in context.EmployeeGenreateOnUpdates)
                {
                    Console.WriteLine(employee.Id + ": " + employee.Name + ", " + employee.LastPayRaise);
                }
            }
        }
    }
}
