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

        public DbSet<CarA> CarAs { get; set; }
        public DbSet<RecordOfSale> RecordOfSales { get; set; }

        public DbSet<BlogD> BlogDs { get; set; }
        public DbSet<PostD> PostDs { get; set; }

        public DbSet<CarB> CarBs { get; set; }
        public DbSet<RecordOfSaleB> RecordOfSaleBs { get; set; }

        public DbSet<CarC> CarCs { get; set; }
        public DbSet<RecordOfSaleC> RecordOfSaleCs { get; set; }

        public DbSet<BlogE> BlogEs { get; set; }
        public DbSet<BlogImage> BlogImageS { get; set; }

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

            modelBuilder.Entity<CarA>()
                .HasKey(c => new { c.State, c.LicensePlate });

            modelBuilder.Entity<RecordOfSale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.SaleHistory)
                .HasForeignKey(s => new { s.CarState, s.CarLicensePlate });

            // Add the shadow property to the model
            modelBuilder.Entity<PostD>()
                .Property<int>("BlogForeignKey");

            // Use the shadow property as a foreign key
            modelBuilder.Entity<PostD>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey("BlogForeignKey");

            modelBuilder.Entity<RecordOfSaleB>()
                .HasOne(s => s.Car)
                .WithMany(c => c.SaleHistory)
                .HasForeignKey(s => s.CarLicensePlate)
                .HasPrincipalKey(c => c.LicensePlate);

            modelBuilder.Entity<RecordOfSaleC>()
                .HasOne(s => s.Car)
                .WithMany(c => c.SaleHistory)
                .HasForeignKey(s => new { s.CarState, s.CarLicensePlate })
                .HasPrincipalKey(c => new { c.State, c.LicensePlate });

            modelBuilder.Entity<BlogE>()
                .HasOne(p => p.BlogImage)
                .WithOne(i => i.Blog)
                .HasForeignKey<BlogImage>(b => b.BlogForeignKey);
        }
    }
}
