using EliteThreadsWebApp.Services.ShoppingCart.Domain;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.ShoppingCart.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<CartHeader> CartHeaders { get; init; }
        public DbSet<CartDetail> CartDetails { get; init; }
        public DbSet<Product> Products { get; init; }
    }
}
