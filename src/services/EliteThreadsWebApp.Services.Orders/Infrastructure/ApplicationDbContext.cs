using EliteThreadsWebApp.Services.Orders.Domain;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Orders.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<OrderHeaderEntity> OrderHeaders { get; init; }
        public DbSet<OrderDetailEntity> OrderDetails { get; init; }
        public DbSet<OrderProductEntity> OrderProducts { get; init; }
        public DbSet<PersonalInfo> PersonalInfos { get; init; }
    }
}
