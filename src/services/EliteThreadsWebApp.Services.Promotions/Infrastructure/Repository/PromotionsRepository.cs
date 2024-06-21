using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Promotions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository
{
    public class PromotionsRepository(ApplicationDbContext db) : IPromotionsRepository
    {
        public async Task<bool> AddDiscountToProductAsync(int discountId, int productId)
        {
            if (db.Discounts.Select(d => d.DiscountId).Contains(discountId))
            {
                var productFromDb = await db.Products.FirstOrDefaultAsync(
                    p => p.ProductId == productId
                );
                if (productFromDb == null)
                {
                    var newProduct = db.Products.Add(new Product { ProductId = productId });
                    newProduct.Entity.DiscountId = discountId;
                    return await Save();
                }
                productFromDb.DiscountId = discountId;
                return await Save();
            }
            else
                throw new InvalidDataException("Object doesn't exist");
        }

        public async Task<bool> AddCollectionToProductAsync(int collectionId, int productId)
        {
            if (db.Collections.Select(c => c.CollectionId).Contains(collectionId))
            {
                var productFromDb = await db.Products.FirstOrDefaultAsync(
                    p => p.ProductId == productId
                );
                if (productFromDb == null)
                {
                    var newProduct = db.Products.Add(new Product { ProductId = productId });

                    newProduct.Entity.CollectionId = collectionId;
                    return await Save();
                }
                productFromDb.CollectionId = collectionId;
                return await Save();
            }
            else
                throw new InvalidDataException("Object doesn't exist.");
        }

        public async Task<bool> CreateDiscountAsync(Discount discount)
        {
            db.Discounts.Add(discount);
            return await Save();
        }

        public async Task<bool> CreateCollectionsAsync(Collections collection)
        {
            db.Collections.Add(collection);
            return await Save();
        }

        public async Task<bool> CreatePromotionMessageAsync(string message)
        {
            db.Promotions.Add(new ActivePromotions { Message = message });
            return await Save();
        }

        public async Task<IEnumerable<Discount>> GetActiveDiscountsAsync()
        {
            return await db.Discounts.ToListAsync();
        }

        public async Task<IEnumerable<Collections>> GetCollectionsAsync()
        {
            return await db.Collections.ToListAsync();
        }

        public async Task<IEnumerable<ActivePromotions>> GetActivePromotionMessagesAsync()
        {
            return await db.Promotions.ToListAsync();
        }

        public async Task<Product?> GetPromotionsByProductIdAsync(int productId)
        {
            return await db.Products
                    .Include(p => p.Discount)
                    .Include(p => p.Collections)
                    .FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new InvalidDataException("Object doesn't exist");
        }

        public async Task<bool> RemoveCollectionFromProductAsync(int productId, int collectionId)
        {
            var productFromDb =
                await db.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new InvalidDataException("Object doesn't exist.");
            if (productFromDb.CollectionId == collectionId)
            {
                productFromDb.CollectionId = null;
                return await Save();
            }

            return false;
        }

        public async Task<bool> RemoveDiscountFromProductAsync(int productId, int discountId)
        {
            var productFromDb =
                await db.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                ?? throw new InvalidDataException("Object doesn't exist.");
            if (productFromDb.DiscountId == discountId)
            {
                productFromDb.DiscountId = null;
                return await Save();
            }

            return false;
        }

        public async Task<OnDeletion> DeleteDiscountAsync(int discountId)
        {
            var discountFromDb =
                await db.Discounts.FirstOrDefaultAsync(d => d.DiscountId == discountId)
                ?? throw new InvalidDataException("Object doesn't exist");
            db.Discounts.Remove(discountFromDb);

            var productIds = await db.Products
                .Where(p => p.DiscountId == discountId)
                .Select(p => p.ProductId)
                .ToListAsync();
            var isSuccessful = await Save();

            return new OnDeletion { IsSuccessful = isSuccessful, ProductIds = productIds };
        }

        public async Task<OnDeletion> DeleteCollectionAsync(int collectionId)
        {
            var collectionFromDb =
                await db.Collections.FirstOrDefaultAsync(d => d.CollectionId == collectionId)
                ?? throw new InvalidDataException("Object doesn't exist");
            db.Collections.Remove(collectionFromDb);
            var productIds = await db.Products
                .Where(p => p.CollectionId == collectionId)
                .Select(p => p.ProductId)
                .ToListAsync();
            var isSuccessful = await Save();

            return new OnDeletion { IsSuccessful = isSuccessful, ProductIds = productIds };
        }

        public async Task<bool> DeletePromotionAsync(int promotionId)
        {
            var promotionFromDb =
                await db.Promotions.FirstOrDefaultAsync(p => p.PromotionId == promotionId)
                ?? throw new InvalidDataException("Object doesn't exist");
            db.Promotions.Remove(promotionFromDb);
            return await Save();
        }

        private async Task<bool> Save()
        {
            var result = await db.SaveChangesAsync();
            return result > 0;
        }
    }
}
