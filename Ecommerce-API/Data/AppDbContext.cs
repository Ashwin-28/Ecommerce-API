using Ecommerce_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Data
{
    public class AppDbContext : IdentityDbContext<User, Microsoft.AspNetCore.Identity.IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        // Identity will manage Users set via IdentityDbContext
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

    }
}
