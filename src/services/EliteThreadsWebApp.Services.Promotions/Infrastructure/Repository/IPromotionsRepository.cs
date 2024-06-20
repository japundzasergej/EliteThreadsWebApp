using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Promotions.Domain.Entities;

namespace EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository
{
    public interface IPromotionsRepository
    {
        Task<bool> CreateDiscountAsync(Discount discount);
        Task<bool> CreateCollectionsAsync(Collections collection);
        Task<bool> CreatePromotionMessageAsync(string message);
        Task<bool> AddDiscountToProductAsync(int discountId, int productId);
        Task<bool> AddCollectionToProductAsync(int collectionId, int productId);
        Task<IEnumerable<Discount>> GetActiveDiscountsAsync();
        Task<IEnumerable<ActivePromotions>> GetActivePromotionMessagesAsync();
        Task<IEnumerable<Collections>> GetCollectionsAsync();
        Task<Product?> GetPromotionsByProductIdAsync(int productId);
        Task<OnDeletion> DeleteDiscountAsync(int discountId);
        Task<OnDeletion> DeleteCollectionAsync(int collectionId);
        Task<bool> DeletePromotionAsync(int promotionId);
        Task<bool> RemoveDiscountFromProductAsync(int productId, int discountId);
        Task<bool> RemoveCollectionFromProductAsync(int productId, int collectionId);
    }
}
