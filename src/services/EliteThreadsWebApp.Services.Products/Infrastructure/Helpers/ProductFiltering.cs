using CloudinaryDotNet;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Products.Domain.Enums;

namespace EliteThreadsWebApp.Services.Products.Infrastructure.Helpers
{
    public static class ProductFiltering
    {
        public static IQueryable<Product> Filter(IQueryable<Product> source, QueryObject query)
        {
            if (!string.IsNullOrEmpty(query.Search))
            {
                source = source.Where(
                    q =>
                        q.ProductName.StartsWith(query.Search)
                        || q.Subcategories.SubcategoryName.StartsWith(query.Search)
                );
            }
            if (query.Category != null)
            {
                source = source.Where(
                    q => q.Subcategories.Categories.CategoryName == query.Category
                );
            }
            if (query.Subcategory != null)
            {
                source = source.Where(q => q.Subcategories.SubcategoryName == query.Subcategory);
            }
            if (query.New != null)
            {
                bool isNew = query.New == "true";
                source = source.Where(q => q.New == isNew);
            }
            if (query.MustHave != null)
            {
                bool mustHave = query.MustHave == "true";
                source = source.Where(q => q.MustHave == mustHave);
            }

            if (query.Size != null)
            {
                if (Enum.TryParse(query.Size, out Size size))
                {
                    source = source.Where(q => q.Size.Contains(size));
                }
                else
                {
                    throw new InvalidOperationException("Invalid size filtering input");
                }
            }
            if (query.Color != null)
            {
                source = source.Where(q => q.Color.Contains(query.Color));
            }
            if (query.Composition != null)
            {
                source = source.Where(q => q.Compositions == query.Composition);
            }
            if (query.PriceMax != null && query.PriceMin != null)
            {
                double priceMin;
                double priceMax;
                if (double.TryParse(query.PriceMin, out double minResult))
                {
                    priceMin = minResult;
                }
                else
                {
                    priceMin = default;
                }
                if (double.TryParse(query.PriceMax, out double maxResult))
                {
                    priceMax = maxResult;
                }
                else
                {
                    priceMax = default;
                }
                source = source.Where(q => q.Price >= priceMin && q.Price <= priceMax);
            }
            if (query.Collection != null)
            {
                source = source.Where(q => q.CollectionName == query.Collection);
            }
            return source;
        }

        public static IQueryable<Product> SortProducts(IQueryable<Product> source, string? orderBy)
        {
            if (!string.IsNullOrEmpty(orderBy))
            {
                return orderBy switch
                {
                    "priceAsc" => source.OrderBy(q => q.Price),
                    "priceDesc" => source.OrderByDescending(q => q.Price),
                    _ => source
                };
            }
            return source;
        }
    }
}
