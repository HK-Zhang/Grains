using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class SchoolEFContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Weibo> Weibo { get; set; }
        public DbSet<WeiPost> WeiPost { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Flower> Flower { get; set; }

        public SchoolEFContext()
            : base("SchoolContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Blog>().HasKey(t => t.PrimaryTrackingKey);

            modelBuilder.Entity<Blog>().Property(t => t.PrimaryTrackingKey).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Blog>().Property(t => t.BloggerName).HasMaxLength(50);
            modelBuilder.Entity<Blog>().Property(t => t.BloggerName).IsRequired();
            modelBuilder.Entity<Blog>().Property(t => t.BloggerName).HasColumnName("BlogName");
            modelBuilder.Entity<Blog>().Property(t => t.BloggerName).IsUnicode(false);
            modelBuilder.Entity<Blog>().Property(t => t.TimeStamp).IsRowVersion();

            modelBuilder.Entity<Blog>().Ignore(t => t.BlogCode);

            modelBuilder.Entity<Post>().ToTable("T_Post");
            modelBuilder.Entity<Post>().Property(t => t.Title).HasColumnType("varchar");
            modelBuilder.Entity<Post>()
                .HasRequired(c => c.Blog)
                .WithMany(t => t.Posts)
                .Map(m => m.MapKey("BlogId"));
            modelBuilder.Entity<Post>().Property(t => t.TimeStamp).IsConcurrencyToken();
            

            modelBuilder.ComplexType<BlogDetails>().Property(t => t.Description).HasMaxLength(1000);

            modelBuilder.Entity<Course>().Property(t => t.DepartmentID).IsOptional();
            modelBuilder.Entity<Course>().HasMany(t => t.Instructors)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseInstructor");
                    m.MapLeftKey("CourseID");
                    m.MapRightKey("InstructorID");
                });

            modelBuilder.Entity<Weibo>().MapToStoredProcedures(s => s.Update(u => u.HasName("modify_Weibo")
                .Parameter(b => b.WeiboId, "weibo_id")
                .Parameter(b => b.Name, "weibo_name")
                .Parameter(b => b.Url, "weibo_url"))
                .Delete(d => d.HasName("delete_Weibo")
                    .Parameter(b => b.WeiboId, "weibo_id"))
                .Insert(i => i.HasName("insert_Weibo")
                    .Parameter(b => b.Name, "weibo_name")
                   .Parameter(b => b.Url, "weibo_url")
                   .Result(b => b.WeiboId, "generated_weibo_identity")));

            modelBuilder.Entity<WeiPost>().MapToStoredProcedures();

            //modelBuilder.Entity<WeiPost>().MapToStoredProcedures(s => s.Insert(i => i.Parameter(p => p.Weibo.WeiboId, "weibo_id")));

            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new GradeMap());
            modelBuilder.Configurations.Add(new FlowerMap());

        }
    }
}
