using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.EfSql.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.EfSql
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogExculudeType> BlogExculudeTypes { get; set; }
        public DbSet<BlogExcludeProperty> BlogExcludePropertys { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();

            modelBuilder.Ignore<BlogMetadata>();

            modelBuilder.Entity<BlogExcludeProperty>()
                .Ignore(b => b.LoadedFromDatabase);
        }
    }
}
