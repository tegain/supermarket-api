using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(category => category.Id);
            modelBuilder.Entity<Category>().Property(category => category.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(category => category.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Category>().HasMany(category => category.Products).WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 100, Name = "Fruits and vegetables"},
                new Category {Id = 101, Name = "Dairy"}
            );

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().HasKey(product => product.Id);
            modelBuilder.Entity<Product>().Property(product => product.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(product => product.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(product => product.QuantityInPackage).IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.UnitOfMeasurement).IsRequired();
        }
    }
}