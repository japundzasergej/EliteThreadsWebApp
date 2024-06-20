using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Products.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Products.Infrastructure.Repository
{
    public class ProductRepository(ApplicationDbContext db) : IProductRepository
    {
        public async Task<bool> CreateProductAsync(Product product)
        {
            db.Products.Add(product);
            return await Save();
        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
            db.Remove(product);
            return await Save();
        }

        public async Task<Product> GetProductByIdNoTrackAsync(int productId)
        {
            var userProduct =
                await db.Products
                    .AsNoTracking()
                    .Include(p => p.Subcategories)
                    .ThenInclude(p => p.Categories)
                    .FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new InvalidDataException("Object doesn't exist.");
            return userProduct;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var userProduct =
                await db.Products
                    .Include(p => p.Subcategories)
                    .ThenInclude(p => p.Categories)
                    .FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new InvalidDataException("Object doesn't exist.");
            return userProduct;
        }

        public async Task<PaginatedList> GetProductsAsync(QueryObject queryObject)
        {
            var productQuery = db.Products.AsQueryable();
            productQuery = ProductFiltering.Filter(productQuery, queryObject);
            productQuery = ProductFiltering.SortProducts(productQuery, queryObject.OrderBy);
            var pageIndex = queryObject.Page ?? 1;
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            var pageSize = queryObject.PageNumber ?? 16;
            var paginatedList = await PaginatedList.CreateAsync(
                productQuery.Include(p => p.Subcategories).ThenInclude(p => p.Categories),
                pageIndex,
                pageSize
            );
            return paginatedList;
        }

        public async Task<IEnumerable<Product>> GetProductsOnWishlistAsync(params int[] productIds)
        {
            var products = new List<Product>();
            foreach (var productId in productIds)
            {
                var product =
                    await db.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                    ?? throw new InvalidDataException("Object doesn't exist.");
                products.Add(product);
            }
            return products;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            db.Update(product);
            return await Save();
        }

        public async Task OnCollectionChangedAsync(
            int? productId,
            int? collectionId,
            string? collectionName
        )
        {
            if (productId == null)
            {
                throw new InvalidDataException("Object doesn't exist");
            }

            var productFromDb =
                await db.Products.FindAsync(productId)
                ?? throw new InvalidDataException("Object doesn't exist");
            if (collectionId != null || collectionName != null)
            {
                productFromDb.CollectionId = collectionId;
                productFromDb.CollectionName = collectionName;
                productFromDb.IsInCollection = true;
                await Save();
            }
            else
            {
                productFromDb.CollectionId = null;
                productFromDb.CollectionName = null;
                productFromDb.IsInCollection = false;
                await Save();
            }
        }

        public async Task OnDiscountChangedAsync(
            int? productId,
            int? discountId,
            string? discountName,
            int? discountAmount
        )
        {
            if (productId == null)
            {
                throw new InvalidDataException("Object doesn't exist");
            }

            var productFromDb =
                await db.Products.FindAsync(productId)
                ?? throw new InvalidDataException("Object doesn't exist");
            if (discountId != null || discountAmount != null || discountName != null)
            {
                productFromDb.DiscountId = discountId;
                productFromDb.DiscountName = discountName;
                productFromDb.DiscountAmount = discountAmount;
                productFromDb.HasDiscount = true;
                await Save();
            }
            else
            {
                productFromDb.DiscountId = null;
                productFromDb.DiscountName = null;
                productFromDb.DiscountAmount = null;
                productFromDb.HasDiscount = false;
                await Save();
            }
        }

        public async Task OnDiscountDeletedAsync(params int[] productIds)
        {
            foreach (var productId in productIds)
            {
                var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    product.DiscountId = null;
                    product.DiscountName = null;
                    product.DiscountAmount = null;
                    product.HasDiscount = false;
                }
            }
            await Save();
        }

        public async Task OnCollectionDeletedAsync(params int[] productIds)
        {
            foreach (var productId in productIds)
            {
                var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    product.CollectionId = null;
                    product.CollectionName = null;
                    product.IsInCollection = false;
                }
            }
            await Save();
        }

        public async Task OnRatingChangedAsync(int productId, float rating, int totalRatingCount)
        {
            var product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product != null)
            {
                product.Rating = rating;
                product.TotalRatingCount = totalRatingCount;
                await Save();
            }
        }

        private async Task<bool> Save()
        {
            var result = await db.SaveChangesAsync();
            return result > 0;
        }

        public async Task OnSuccessfulPayment(params int[] productIds)
        {
            foreach (var productId in productIds)
            {
                var productFromDb =
                    await db.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                    ?? throw new InvalidDataException("Object doesn't exist");
                productFromDb.ProductsLeft--;
                if (productFromDb.ProductsLeft == 0)
                {
                    productFromDb.IsInStock = false;
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
