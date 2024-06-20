using EliteThreadsWebApp.Services.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Products.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<Product> Products { get; init; }
        public DbSet<Categories> Categories { get; init; }
        public DbSet<Subcategories> Subcategories { get; init; }

        //protected override void onmodelcreating(modelbuilder modelbuilder)
        //{
        //    base.onmodelcreating(modelbuilder);
        //    modelbuilder.seeddata();
        //}
    }
}
