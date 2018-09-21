﻿// <auto-generated />
using System;
using ConsoleApp.EfSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp.EfSql.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new { BlogId = 1, Url = "http://sample.com" }
                    );
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogExcludeProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("BlogExcludePropertys");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogExculudeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("BlogExculudeTypes");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogF", b =>
                {
                    b.Property<int>("BlogFId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogFId");

                    b.HasIndex("Url");

                    b.ToTable("BlogFs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogG", b =>
                {
                    b.Property<int>("BlogGId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogGId");

                    b.ToTable("BlogGs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogH", b =>
                {
                    b.Property<int>("BlogHId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Url");

                    b.HasKey("BlogHId");

                    b.ToTable("BlogHs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BlogH");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogI", b =>
                {
                    b.Property<int>("BlogIId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogIId");

                    b.ToTable("BlogIs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogJ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BlogJs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogK", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BlogKs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogL", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Name");

                    b.HasKey("_id");

                    b.ToTable("BlogLs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogM", b =>
                {
                    b.Property<int>("BlogMId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("BlogMId");

                    b.ToTable("BlogMs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogMaxLength", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("BlogMaxLengths");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogShadowProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("BlogShadowPropertys");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogTimestamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("BlogTimestamps");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.BlogValueGenerated", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Inserted");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("BlogValueGenerteds");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Car", b =>
                {
                    b.Property<string>("LicensePlate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("LicensePlate");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.CarComKey", b =>
                {
                    b.Property<string>("State");

                    b.Property<string>("LicensePlate");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("State", "LicensePlate");

                    b.ToTable("CarComKeys");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.CarD", b =>
                {
                    b.Property<int>("CarDId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LicensePlate")
                        .IsRequired();

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("CarDId");

                    b.HasAlternateKey("LicensePlate");

                    b.ToTable("CarDs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.CarE", b =>
                {
                    b.Property<int>("CarEId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LicensePlate")
                        .IsRequired();

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("CarEId");

                    b.HasAlternateKey("State", "LicensePlate");

                    b.ToTable("CarEs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.OrderA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("OrderAs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.OrderC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("OrderCs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName")
                        .IsConcurrencyToken();

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PersonB", b =>
                {
                    b.Property<int>("PersonBId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("PersonBId");

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("PersonB");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");

                    b.HasData(
                        new { PostId = 1, BlogId = 3, Content = "Test 1", Title = "First post" },
                        new { PostId = 2, BlogId = 3, Content = "Test 2", Title = "Second post" }
                    );
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostJ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostedOn");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("PostJs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostK", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostedOn");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("PostKs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostL", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Blog_id");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostedOn");

                    b.Property<string>("Title");

                    b.HasKey("_id");

                    b.HasIndex("Blog_id");

                    b.ToTable("PostLs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostM", b =>
                {
                    b.Property<int>("PostMId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogMId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostMId");

                    b.HasIndex("BlogMId");

                    b.ToTable("PostMs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mount")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Riders");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.RssBlog", b =>
                {
                    b.HasBaseType("ConsoleApp.EfSql.Model.BlogH");

                    b.Property<string>("RssUrl");

                    b.ToTable("RssBlog");

                    b.HasDiscriminator().HasValue("RssBlog");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Order", b =>
                {
                    b.OwnsOne("ConsoleApp.EfSql.Model.StreetAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City");

                            b1.Property<string>("Street");

                            b1.ToTable("Orders");

                            b1.HasOne("ConsoleApp.EfSql.Model.Order")
                                .WithOne("ShippingAddress")
                                .HasForeignKey("ConsoleApp.EfSql.Model.StreetAddress", "OrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.OrderA", b =>
                {
                    b.OwnsOne("ConsoleApp.EfSql.Model.StreetAddress", "ShippingAddress", b1 =>
                        {
                            b1.Property<int>("OrderAId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnName("ShipsToCity");

                            b1.Property<string>("Street")
                                .HasColumnName("ShipsToStreet");

                            b1.ToTable("OrderAs");

                            b1.HasOne("ConsoleApp.EfSql.Model.OrderA")
                                .WithOne("ShippingAddress")
                                .HasForeignKey("ConsoleApp.EfSql.Model.StreetAddress", "OrderAId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.OrderC", b =>
                {
                    b.OwnsOne("ConsoleApp.EfSql.Model.OrderDetails", "OrderDetails", b1 =>
                        {
                            b1.Property<int?>("OrderCId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.ToTable("OrderCs");

                            b1.HasOne("ConsoleApp.EfSql.Model.OrderC")
                                .WithOne("OrderDetails")
                                .HasForeignKey("ConsoleApp.EfSql.Model.OrderDetails", "OrderCId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("ConsoleApp.EfSql.Model.StreetAddress", "BillingAddress", b2 =>
                                {
                                    b2.Property<int?>("OrderDetailsOrderCId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("City");

                                    b2.Property<string>("Street");

                                    b2.ToTable("OrderCs");

                                    b2.HasOne("ConsoleApp.EfSql.Model.OrderDetails")
                                        .WithOne("BillingAddress")
                                        .HasForeignKey("ConsoleApp.EfSql.Model.StreetAddress", "OrderDetailsOrderCId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("ConsoleApp.EfSql.Model.StreetAddress", "ShippingAddress", b2 =>
                                {
                                    b2.Property<int?>("OrderDetailsOrderCId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("City");

                                    b2.Property<string>("Street");

                                    b2.ToTable("OrderCs");

                                    b2.HasOne("ConsoleApp.EfSql.Model.OrderDetails")
                                        .WithOne("ShippingAddress")
                                        .HasForeignKey("ConsoleApp.EfSql.Model.StreetAddress", "OrderDetailsOrderCId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.Post", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Model.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostJ", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Model.BlogJ", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostK", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Model.BlogK", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostL", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Model.BlogL", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("Blog_id");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Model.PostM", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Model.BlogM")
                        .WithMany("Posts")
                        .HasForeignKey("BlogMId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
