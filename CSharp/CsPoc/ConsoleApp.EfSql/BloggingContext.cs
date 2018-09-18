using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp.EfSql.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        public DbSet<BlogMaxLength> BlogMaxLengths { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<BlogTimestamp> BlogTimestamps { get; set; }
        public DbSet<BlogShadowProperty> BlogShadowPropertys { get; set; }
        public DbSet<BlogF> BlogFs { get; set; }
        public DbSet<CarD> CarDs { get; set; }
        public DbSet<CarE> CarEs { get; set; }
        public DbSet<BlogH> BlogHs { get; set; }
        public DbSet<BlogG> BlogGs { get; set; }
        public DbSet<BlogI> BlogIs { get; set; }
        public DbSet<Rider> Riders { get; set; }

        private readonly ValueConverter _converter = new ValueConverter<EquineBeast, string>(
            v => v.ToString(),
            v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));

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

            modelBuilder.Entity<BlogMaxLength>()
                .Property(b => b.Url)
                .HasMaxLength(500);

            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .IsConcurrencyToken();

            modelBuilder.Entity<BlogTimestamp>()
                .Property(p => p.Timestamp)
                .IsRowVersion();

            modelBuilder.Entity<BlogShadowProperty>()
                .Property<DateTime>("LastUpdated");

            modelBuilder.Entity<BlogF>()
                .HasIndex(b => b.Url);

            //            modelBuilder.Entity<BlogF>()
            //                .HasIndex(b => b.Url)
            //                .IsUnique();

            modelBuilder.Entity<PersonB>()
                .HasIndex(p => new { p.FirstName, p.LastName });

            modelBuilder.Entity<CarD>()
                .HasAlternateKey(c => c.LicensePlate);

            modelBuilder.Entity<CarE>()
                .HasAlternateKey(c => new { c.State, c.LicensePlate });

            modelBuilder.Entity<RssBlog>().HasBaseType<BlogH>();

            modelBuilder.Entity<BlogG>()
                .Property(b => b.Url)
                .HasField("_validatedUrl")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<BlogI>()
                .Property<string>("Url")
                .HasField("_validatedUrl");

            modelBuilder
                .Entity<Rider>()
                .Property(e => e.Mount)
                .HasConversion(_converter);
        }
    }
}
