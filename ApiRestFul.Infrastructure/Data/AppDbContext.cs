using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ApiRestFul.Domain.Models;

namespace ApiRestFul.Infrastructure.Data;

public class AppDbContext : DbContext
{
    // Constructor:
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    // To create the tables on the DB
    public DbSet<Customer> customers_tb { get; set; }
    public DbSet<Order> orders_tb { get; set; }
    public DbSet<OrderDetail> orderDetails_tb{ get; set; }
    public DbSet<Product> products_tb { get; set; }
    
    //To do unique fields:
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.ProductCode)
            .IsUnique();
            
        base.OnModelCreating(modelBuilder);
    }
}