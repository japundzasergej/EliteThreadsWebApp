using EliteThreadsWebApp.Services.Social.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Social.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<Product> Products { get; init; }
        public DbSet<Review> Reviews { get; init; }
        public DbSet<UserRating> UserRatings { get; init; }
        public DbSet<UserWishlist> UserWishlists { get; init; }
    }
}
