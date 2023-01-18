using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Data.Context
{
    public class ContextSettings: DbContext
    {
        public ContextSettings(DbContextOptions options) :base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customerModel = modelBuilder.Entity<Customer>();

            customerModel.ToTable("Customer");
            customerModel.Property("Name").HasColumnType("varchar").HasMaxLength(100);
            customerModel.Property("LastName").HasColumnType("varchar").HasMaxLength(50);
            customerModel.Property("Email").HasColumnType("varchar").HasMaxLength(200);     
            customerModel.HasMany(p=> p.products);
            customerModel.HasKey("Id");

            var userModel = modelBuilder.Entity<User>();
            userModel.ToTable("User");
            userModel.Property("Name").HasColumnType("varchar").HasMaxLength(100);
            userModel.Property("Password").HasColumnType("varchar").HasMaxLength(50);
            userModel.Property("Email").HasColumnType("varchar").HasMaxLength(200);    
            userModel.HasKey("Id");     

            var productModel = modelBuilder.Entity<Product>();
            productModel.ToTable("Product");
            productModel.Property(p => p.Value).HasColumnType("money").IsRequired();
            productModel.Property(p => p.Name).IsRequired().HasMaxLength(250);
            productModel.HasOne(c => c.customer)
                        .WithMany(p=> p.products)
                        .HasForeignKey(x=> x.customerId);
        }
    }
}
