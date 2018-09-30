using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.EfSql.QueryModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp.EfSql
{
    public class QueryingContext : DbContext
    {
        public DbSet<Person> RenMen{ get; set; }
        public DbSet<School> Schools { get; set; }

        public DbSet<Blog> QBlogs { get; set; }
        public DbSet<Post> QPost { get; set; }
        public DbSet<Ren> Ren { get; set; }
        public DbSet<LZBlog> LZBlogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().HasMany(s => s.Students).WithOne(s => s.School);

            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts)
                .WithOne();

            modelBuilder.Entity<Post>()
                .HasMany(b => b.Tags)
                .WithOne();

            modelBuilder.Entity<LZBlog>()
                .HasMany(b => b.Posts)
                .WithOne();

        }
    }
}
