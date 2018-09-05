using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.EfSql.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp.EfSql
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeGenreateOnUpdate> EmployeeGenreateOnUpdates { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(b => b.EmploymentStarted)
                .HasDefaultValueSql("CONVERT(date, GETDATE())");

            modelBuilder.Entity<EmployeeGenreateOnUpdate>()
                .Property(b => b.LastPayRaise)
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<EmployeeGenreateOnUpdate>()
                .Property(b => b.LastPayRaise)
                .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
        }
    }
}
