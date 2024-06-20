using EliteThreadsWebApp.Services.ShoppingCart.Domain;

namespace EliteThreadsWebApp.Services.ShoppingCart.Infrastructure.Repository
{
    public interface IShoppingCartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task CreateUpdateCartAsync(Cart cart);
        Task<bool> RemoveFromCartAsync(int cartDetailsId);
        Task<bool> ClearCartAsync(string userId);
    }
}
