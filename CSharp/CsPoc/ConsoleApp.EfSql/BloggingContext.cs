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
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarComKey> CarComKeys { get; set; }
        public DbSet<BlogValueGenerated> BlogValueGenerteds { get; set; }
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

            modelBuilder.Entity<Car>()
                .HasKey(c => c.LicensePlate);

            modelBuilder.Entity<CarComKey>()
                .HasKey(c => new { c.State, c.LicensePlate });

            modelBuilder.Entity<BlogValueGenerated>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<BlogValueGenerated>()
                .Property(b => b.LastUpdated)
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<BlogValueGenerated>()
                .Property(b => b.LastUpdated)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
