using EliteThreadsWebApp.Services.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Products.Infrastructure
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Categories>()
                .HasData(
                    new Categories { CategoryId = 1, CategoryName = "Clothing" },
                    new Categories { CategoryId = 2, CategoryName = "Accessories" },
                    new Categories { CategoryId = 3, CategoryName = "Shoes" }
                );

            modelBuilder
                .Entity<Subcategories>()
                .HasData(
                    new Subcategories
                    {
                        SubcategoryId = 1,
                        SubcategoryName = "Suits",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 2,
                        SubcategoryName = "Tuxedos",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 3,
                        SubcategoryName = "Blazers",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 4,
                        SubcategoryName = "Dress Shirts",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 5,
                        SubcategoryName = "Casual Shirts",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 6,
                        SubcategoryName = "Polo Shirts",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 7,
                        SubcategoryName = "Overshirts",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 8,
                        SubcategoryName = "Waistcoats",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 9,
                        SubcategoryName = "Knitwear",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 10,
                        SubcategoryName = "Jeans",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 11,
                        SubcategoryName = "Trousers",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 12,
                        SubcategoryName = "Outerwear",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 13,
                        SubcategoryName = "Sweatshirts and Joggers",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 14,
                        SubcategoryName = "Polo T-Shirts",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 15,
                        SubcategoryName = "Bermuda",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 16,
                        SubcategoryName = "Underwear and Pajamas",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 17,
                        SubcategoryName = "Swim Shorts",
                        CategoryId = 1
                    },
                    new Subcategories
                    {
                        SubcategoryId = 18,
                        SubcategoryName = "Ties",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 19,
                        SubcategoryName = "Pocket Squares",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 20,
                        SubcategoryName = "Socks",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 21,
                        SubcategoryName = "Belts",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 22,
                        SubcategoryName = "Hats",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 23,
                        SubcategoryName = "Bow Ties",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 24,
                        SubcategoryName = "Cummerbunds",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 25,
                        SubcategoryName = "Cufflinks",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 26,
                        SubcategoryName = "Braces",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 27,
                        SubcategoryName = "Rucksacks and Suitcases",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 28,
                        SubcategoryName = "Sunglasses",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 29,
                        SubcategoryName = "Small Leather Goods",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 30,
                        SubcategoryName = "Beach Towels",
                        CategoryId = 2
                    },
                    new Subcategories
                    {
                        SubcategoryId = 31,
                        SubcategoryName = "Sneakers",
                        CategoryId = 3
                    },
                    new Subcategories
                    {
                        SubcategoryId = 32,
                        SubcategoryName = "Loafers",
                        CategoryId = 3
                    },
                    new Subcategories
                    {
                        SubcategoryId = 33,
                        SubcategoryName = "Classic",
                        CategoryId = 3
                    },
                    new Subcategories
                    {
                        SubcategoryId = 34,
                        SubcategoryName = "Flip Flops",
                        CategoryId = 3
                    }
                );
        }
    }
}
