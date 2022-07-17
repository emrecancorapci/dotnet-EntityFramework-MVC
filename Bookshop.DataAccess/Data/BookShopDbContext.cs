using System.Collections.Generic;
using Bookshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.DataAccess.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options):base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "mobile_phone",
                    Title = "Mobile Phone",
                },
                new Category()
                {
                    Id = 2,
                    Name = "notebook",
                    Title = "Notebook",
                },
                new Category()
                {
                    Id = 3,
                    Name = "tablet",
                    Title = "Tablet",
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1, Name = "IPhone", Price = 24000, Discount = 0.05, CategoryId = 1,
                    ImgUrl = "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg"
                },
                new Product()
                {
                    Id = 2, Name = "Oppo", Price = 16000, Discount = 0.05, CategoryId = 1,
                    ImgUrl = "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg"
                },
                new Product()
                {
                    Id = 3, Name = "Xiaomi", Price = 11000, Discount = 0.05, CategoryId = 1,
                    ImgUrl = "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg"
                },
                new Product()
                {
                    Id = 4, Name = "Dell", Price = 24000, Discount = 0.05, CategoryId = 2,
                    ImgUrl = "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg"
                },
                new Product()
                {
                    Id = 5, Name = "MSI", Price = 28000, Discount = 0.05, CategoryId = 2,
                    ImgUrl = "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg"
                },
                new Product()
                {
                    Id = 6, Name = "Lenovo", Price = 18000, Discount = 0.05, CategoryId = 2,
                    ImgUrl = "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg"
                }
            );
        }
    }
}