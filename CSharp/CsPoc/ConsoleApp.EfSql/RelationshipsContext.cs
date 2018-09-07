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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostA>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts);
        }
    }
}
