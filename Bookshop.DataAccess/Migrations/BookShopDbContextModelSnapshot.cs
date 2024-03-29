﻿// <auto-generated />
using System;
using Bookshop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookshop.DataAccess.Migrations
{
    [DbContext(typeof(BookShopDbContext))]
    partial class BookShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bookshop.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "mobile_phone",
                            Title = "Mobile Phone"
                        },
                        new
                        {
                            Id = 2,
                            Name = "notebook",
                            Title = "Notebook"
                        },
                        new
                        {
                            Id = 3,
                            Name = "tablet",
                            Title = "Tablet"
                        });
                });

            modelBuilder.Entity("Bookshop.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Discount = 0.050000000000000003,
                            ImgUrl = "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg",
                            IsActive = true,
                            Name = "IPhone",
                            Price = 24000.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Discount = 0.050000000000000003,
                            ImgUrl = "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg",
                            IsActive = true,
                            Name = "Oppo",
                            Price = 16000.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Discount = 0.050000000000000003,
                            ImgUrl = "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg",
                            IsActive = true,
                            Name = "Xiaomi",
                            Price = 11000.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Discount = 0.050000000000000003,
                            ImgUrl = "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg",
                            IsActive = true,
                            Name = "Dell",
                            Price = 24000.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Discount = 0.050000000000000003,
                            ImgUrl = "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg",
                            IsActive = true,
                            Name = "MSI",
                            Price = 28000.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Discount = 0.050000000000000003,
                            ImgUrl = "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg",
                            IsActive = true,
                            Name = "Lenovo",
                            Price = 18000.0
                        });
                });

            modelBuilder.Entity("Bookshop.Entities.Product", b =>
                {
                    b.HasOne("Bookshop.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bookshop.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
