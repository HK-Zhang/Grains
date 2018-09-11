using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.EfSql.Relationships;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.EfSql
{
    public class RelationshipsContext : DbContext

    {
        public DbSet<BlogA> BlogAs { get; set; }
        public DbSet<PostA> PostAs { get; set; }

        public DbSet<BlogB> BlogB { get; set; }
        public DbSet<PostB> PostBs { get; set; }

        public DbSet<BlogC> BlogCs { get; set; }
        public DbSet<PostC> PostCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostA>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts);

            modelBuilder.Entity<BlogB>()
                .HasMany(b => b.Posts)
                .WithOne();

            modelBuilder.Entity<PostC>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogForeignKey);
        }
    }
}
