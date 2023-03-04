using Microsoft.EntityFrameworkCore;
using MinimalAPIS.Models;

namespace MinimalAPIS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)        
        {
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductInfo> ProductInfos {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<ProductCategory>().ToTable(nameof(ProductCategory));
            modelBuilder.Entity<ProductInfo>().ToTable(nameof(ProductInfo));
        }

    }
}