namespace EliteThreadsWebApp.Services.Social.Infrastructure.Interface
{
    public interface IUserWishlistRepository
    {
        Task<IEnumerable<int>> GetWishlistProductsByUserIdAsync(string userId);
        Task<bool> AddProductToWishlistAsync(string userId, int productId);
        Task<bool> RemoveProductFromWishlistAsync(string userId, int productId);
    }
}
