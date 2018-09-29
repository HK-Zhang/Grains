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
        public DbSet<BlogJ> BlogJs { get; set; }
        public DbSet<PostJ> PostJs { get; set; }
        public DbSet<BlogK> BlogKs { get; set; }
        public DbSet<PostK> PostKs { get; set; }
        public DbSet<BlogL> BlogLs { get; set; }
        public DbSet<PostL> PostLs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderA> OrderAs { get; set; }
        public DbSet<OrderC> OrderCs { get; set; }
        public DbSet<BlogM> BlogMs { get; set; }
        public DbSet<PostM> PostMs { get; set; }
        public DbSet<BlogN> BlogNs { get; set; }
        public DbSet<BlogO> BlogOs { get; set; }
        public DbSet<PersonC> PeopleC { get; set; }
        public DbSet<OrderD> OrderDs { get; set; }
        public DbSet<BlogP> BlogPs { get; set; }
        public DbSet<BlogR> BlogRs { get; set; }
        public DbSet<BlogS> BlogSs { get; set; }
        public DbSet<PostS> PostSs { get; set; }
        public DbSet<CarF> CarFs { get; set; }
        public DbSet<BlogT> BlogTs { get; set; }
        public DbSet<BlogU> BlogUs { get; set; }


        private readonly ValueConverter _converter = new ValueConverter<EquineBeast, string>(
            v => v.ToString(),
            v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfSql;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //            modelBuilder.HasDefaultSchema("blogging");

//            modelBuilder.HasSequence<int>("OrderNumbers");
            modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
                .StartsAt(1000)
                .IncrementsBy(5);

            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();

            modelBuilder.Entity<Blog>().HasData(new Blog { BlogId = 1, Url = "http://sample.com" });

            modelBuilder.Entity<Post>().HasData(
                new { BlogId = 3, PostId = 1, Title = "First post", Content = "Test 1" },
                new { BlogId = 3, PostId = 2, Title = "Second post", Content = "Test 2" });

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

            modelBuilder.Entity<BlogL>(
                b =>
                {
                    b.HasKey("_id");
                    b.Property(e => e.Author);
                    b.Property(e => e.Name);
                });

            modelBuilder.Entity<PostL>(
                b =>
                {
                    b.HasKey("_id");
                    b.Property(e => e.Title);
                    b.Property(e => e.PostedOn);
                });

            modelBuilder.Entity<Order>().OwnsOne(p => p.ShippingAddress);
            //In case ShippingAddress is private.
            //modelBuilder.Entity<Order>().OwnsOne(typeof(StreetAddress), "ShippingAddress");

            modelBuilder.Entity<OrderA>().OwnsOne(
                o => o.ShippingAddress,
                sa =>
                {
                    sa.Property(p => p.Street).HasColumnName("ShipsToStreet");
                    sa.Property(p => p.City).HasColumnName("ShipsToCity");
                });

            modelBuilder.Entity<OrderC>().OwnsOne(p => p.OrderDetails, od =>
            {
                od.OwnsOne(c => c.BillingAddress);
                od.OwnsOne(c => c.ShippingAddress);
                //                od.ToTable("OrderDetails"); Storing owned types in separate tables

            });

            modelBuilder
                .Query<BlogPostsCount>().ToView("View_BlogPostCounts")
                .Property(v => v.BlogName).HasColumnName("Name");

            modelBuilder.Entity<BlogN>()
                .ToTable("tblBlogNs");
            //                .ToTable("tblBlogNs", schema: "blogging");

            modelBuilder.Entity<BlogO>(eb =>
            {
                eb.HasKey(b => b.BlogOId)
                    .HasName("PrimaryKey_BlogId");
                eb.Property(b => b.BlogOId)
                    .HasColumnName("blog_id");
                eb.Property(b => b.Url).HasColumnType("varchar(200)");
                eb.Property(b => b.Rating).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<PersonC>()
                .Property(p => p.DisplayName)
                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

            modelBuilder.Entity<OrderD>()
                .Property(o => o.OrderNo)
                .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers");

            modelBuilder.Entity<BlogP>(eb =>
            {
                eb.Property(b => b.Rating)
                    .HasDefaultValue(3);

                eb.Property(b => b.Created)
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<BlogR>()
                .HasIndex(b => b.Url)
                .HasFilter("[Url] IS NOT NULL");

            //            modelBuilder.Entity<BlogR>()
            //                .HasIndex(b => b.Url)
            //                .IsUnique()
            //                .HasFilter(null);

            modelBuilder.Entity<PostS>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogSId)
                .HasConstraintName("ForeignKey_PostS_BlogS");


            modelBuilder.Entity<CarF>()
                .HasAlternateKey(c => c.LicensePlate)
                .HasName("AlternateKey_LicensePlate");

            modelBuilder.Entity<BlogT>()
                .HasDiscriminator<string>("blog_type")
                .HasValue<BlogT>("blog_base")
                .HasValue<RssBlogT>("blog_rss");


            modelBuilder.Entity<BlogU>(b =>
            {
                b.HasDiscriminator<string>("BlogType");

                b.Property(e => e.BlogType)
                    .HasMaxLength(200)
                    .HasColumnName("blog_type");
            });
        }
    }
}
