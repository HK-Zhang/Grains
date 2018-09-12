﻿// <auto-generated />
using System;
using ConsoleApp.EfSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    [DbContext(typeof(RelationshipsContext))]
    partial class RelationshipsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.BlogA", b =>
                {
                    b.Property<int>("BlogAId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogAId");

                    b.ToTable("BlogAs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.BlogB", b =>
                {
                    b.Property<int>("BlogBId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogBId");

                    b.ToTable("BlogB");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.BlogC", b =>
                {
                    b.Property<int>("BlogCId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogCId");

                    b.ToTable("BlogCs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.BlogD", b =>
                {
                    b.Property<int>("BlogDId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url");

                    b.HasKey("BlogDId");

                    b.ToTable("BlogDs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.CarA", b =>
                {
                    b.Property<string>("State");

                    b.Property<string>("LicensePlate");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("State", "LicensePlate");

                    b.ToTable("CarAs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.CarB", b =>
                {
                    b.Property<int>("CarBId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LicensePlate")
                        .IsRequired();

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.HasKey("CarBId");

                    b.ToTable("CarBs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostA", b =>
                {
                    b.Property<int>("PostAId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogAId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostAId");

                    b.HasIndex("BlogAId");

                    b.ToTable("PostAs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostB", b =>
                {
                    b.Property<int>("PostBId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogBId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostBId");

                    b.HasIndex("BlogBId");

                    b.ToTable("PostBs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostC", b =>
                {
                    b.Property<int>("PostCId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogForeignKey");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostCId");

                    b.HasIndex("BlogForeignKey");

                    b.ToTable("PostCs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostD", b =>
                {
                    b.Property<int>("PostDId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogForeignKey");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostDId");

                    b.HasIndex("BlogForeignKey");

                    b.ToTable("PostDs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.RecordOfSale", b =>
                {
                    b.Property<int>("RecordOfSaleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarLicensePlate");

                    b.Property<string>("CarState");

                    b.Property<DateTime>("DateSold");

                    b.Property<decimal>("Price");

                    b.HasKey("RecordOfSaleId");

                    b.HasIndex("CarState", "CarLicensePlate");

                    b.ToTable("RecordOfSales");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.RecordOfSaleB", b =>
                {
                    b.Property<int>("RecordOfSaleBId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarLicensePlate");

                    b.Property<DateTime>("DateSold");

                    b.Property<decimal>("Price");

                    b.HasKey("RecordOfSaleBId");

                    b.HasIndex("CarLicensePlate");

                    b.ToTable("RecordOfSaleBs");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostA", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Relationships.BlogA", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogAId");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostB", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Relationships.BlogB")
                        .WithMany("Posts")
                        .HasForeignKey("BlogBId");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostC", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Relationships.BlogC", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.PostD", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Relationships.BlogD", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.RecordOfSale", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Relationships.CarA", "Car")
                        .WithMany("SaleHistory")
                        .HasForeignKey("CarState", "CarLicensePlate");
                });

            modelBuilder.Entity("ConsoleApp.EfSql.Relationships.RecordOfSaleB", b =>
                {
                    b.HasOne("ConsoleApp.EfSql.Relationships.CarB", "Car")
                        .WithMany("SaleHistory")
                        .HasForeignKey("CarLicensePlate")
                        .HasPrincipalKey("LicensePlate");
                });
#pragma warning restore 612, 618
        }
    }
}
