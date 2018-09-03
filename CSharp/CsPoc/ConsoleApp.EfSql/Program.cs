using System;
using ConsoleApp.EfSql.Model;

namespace ConsoleApp.EfSql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello EntityFramework Core!");

            var democase = "ExecludeTypesSample";

            switch (democase)
            {
                case "SimpleSample":
                    SimpleSample();
                    break;
                case "ExecludeTypesSample":
                    ExecludeTypesSample();
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
    }
}
