using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            if (dataDir.EndsWith(@"\bin\Debug\") || dataDir.EndsWith(@"\bin\Release\"))
            {
                dataDir = System.IO.Directory.GetParent(dataDir).Parent.Parent.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }

            using (var db = new SchoolEFContext())
            {
                
                Department department = new Department();
                department.Name = "Math";
                db.Departments.Add(department);
                db.SaveChanges();

                db.Configuration.LazyLoadingEnabled = true;
                var query = from b in db.Departments
                            orderby b.Name
                            select b;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                    //Console.WriteLine(item.Courses.Count());
                }

                var blogs1 = db.Blogs.AsNoTracking();
                var query2 = from b in db.Blogs
                             select b;

                foreach (var item in query2)
                {
                    Console.WriteLine(item.BlogCode);
                }

            }

            using (var db = new SchoolEFContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.LazyLoadingEnabled = true;
                var courses = db.Course.Include("Instructors").ToList();

                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                    db.Entry(item).Collection(p => p.Instructors).Load();
                    Console.WriteLine(item.Instructors.Count());
                }

                db.Configuration.AutoDetectChangesEnabled = true;
            }

            using (var db = new LazyLoadingDBContext())
            {
                var courses = db.Course.ToList();
                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.Instructors.Count());
                }

                var person = db.Person.SqlQuery("SELECT * FROM Person").ToList();
                Console.WriteLine(person.FirstOrDefault().Name);


            }

            Console.ReadKey();

        }
    }
}
