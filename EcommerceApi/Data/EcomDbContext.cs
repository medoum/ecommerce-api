using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class EcomDbContext : DbContext
    {
        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductOwner> ProductOwners { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.ProductCategories)
                    .HasForeignKey(c => c.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductOwner>()
                    .HasKey(po => new { po.ProductId, po.UserId });
            modelBuilder.Entity<ProductOwner>()
                    .HasOne(p => p.Product)
                    .WithMany(pc => pc.ProductOwners)
                    .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductOwner>()
                    .HasOne(p => p.User)
                    .WithMany(pc => pc.ProductOwners)
                    .HasForeignKey(c => c.UserId);
        }
    }
}

