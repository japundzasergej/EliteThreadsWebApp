using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Promotions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Promotions.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<Discount> Discounts { get; init; }
        public DbSet<ActivePromotions> Promotions { get; init; }
        public DbSet<Collections> Collections { get; init; }
        public DbSet<Product> Products { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Discount)
                .WithMany()
                .HasForeignKey(p => p.DiscountId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Collections)
                .WithMany()
                .HasForeignKey(p => p.CollectionId)
                .OnDelete(DeleteBehavior.SetNull);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder
            //    .Entity<Discount>()
            //    .HasData(
            //        new Discount
            //        {
            //            DiscountId = 1,
            //            DiscountName = "30% OFF",
            //            DiscountAmount = 30
            //        },
            //        new Discount
            //        {
            //            DiscountId = 2,
            //            DiscountName = "20% OFF",
            //            DiscountAmount = 20
            //        },
            //        new Discount
            //        {
            //            DiscountId = 3,
            //            DiscountName = "10% OFF",
            //            DiscountAmount = 10
            //        }
            //    );
            //modelBuilder
            //    .Entity<ActivePromotions>()
            //    .HasData(
            //        new ActivePromotions
            //        {
            //            PromotionId = 1,
            //            Message = "MID SEASON SALE: up to -30% with free delivery for all orders"
            //        },
            //        new ActivePromotions
            //        {
            //            PromotionId = 2,
            //            Message = "FREE SHIPPING ON ORDERS OVER 80€"
            //        }
            //    );
        }
    }
}
