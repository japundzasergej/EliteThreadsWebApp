using EliteThreadsWebApp.Services.Products.Domain;
using EliteThreadsWebApp.Services.Products.Domain.Entities;
using EliteThreadsWebApp.Services.Products.Infrastructure.Helpers;

namespace EliteThreadsWebApp.Services.Products.Infrastructure.Repository
{
    public interface IProductRepository
    {
        Task<PaginatedList> GetProductsAsync(QueryObject queryObject);
        Task<IEnumerable<Product>> GetProductsOnWishlistAsync(params int[] productIds);
        Task<Product> GetProductByIdAsync(int productId);
        Task<bool> CreateProductAsync(Product product);
        Task<Product> GetProductByIdNoTrackAsync(int productId);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Product product);
        Task OnDiscountChangedAsync(
            int? productId,
            int? discountId,
            string? discountName,
            int? discountAmount
        );
        Task OnCollectionChangedAsync(int? productId, int? collectionId, string? collectionName);
        Task OnDiscountDeletedAsync(params int[] productIds);
        Task OnCollectionDeletedAsync(params int[] productIds);
        Task OnRatingChangedAsync(int productId, float rating, int totalRatingCount);
        Task OnSuccessfulPayment(IEnumerable<SubtractQuantityFromProduct> subtractQuantities);
    }
}
