using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class SchoolDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<SchoolEFContext>
    {
        protected override void Seed(SchoolEFContext context)
        {
            Department department = new Department();
            department.Name = "IT";
            department.Courses = new List<Course> { new Course { Title = "Phsic" }, new Course { Title = "Computer" } };
            context.Set<Department>().Add(department);
            context.Set<Department>().Add(new Department { Name = "ART" });
            context.Set<Department>().Add(new Department { Name = "English" });
            context.Set<Department>().Add(new Department { Name = "Construction" });
            context.Set<Department>().Add(new Department { Name = "Science" });
            context.SaveChanges();

            Course course = department.Courses.FirstOrDefault();
            course.Instructors = new List<Person> { new Person { Name = "Henry", DepartmentChairman = new List<Department> { department } } };
            context.SaveChanges();

            Person person = context.Person.FirstOrDefault();


            var query = from b in context.Departments
                        orderby b.Name
                        select b;

            foreach (var item in query)
            {
                item.Teacher = person;
            }
            context.SaveChanges();

            context.Set<Course>().AddRange(new List<Course> { new Course { Title = "R", DepartmentID = 1 }, new Course { Title = "Java", DepartmentID = 1 }, new Course { Title = "C#", DepartmentID = 1 } });
            context.SaveChanges();
          

            Blog blog = new Blog();
            blog.PrimaryTrackingKey = 1;
            blog.BloggerName = "My Blog";
            blog.BlogDetail = new BlogDetails {Description="haha" };
            context.Set<Blog>().Add(blog);

            base.Seed(context);
        }
    }
}
