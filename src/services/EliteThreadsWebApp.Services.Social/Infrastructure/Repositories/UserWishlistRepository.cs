using EliteThreadsWebApp.Services.Social.Domain.Entities;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;

namespace EliteThreadsWebApp.Services.Social.Infrastructure.Repositories
{
    public class UserWishlistRepository(ApplicationDbContext db) : IUserWishlistRepository
    {
        public async Task<bool> AddProductToWishlistAsync(string userId, int productId)
        {
            var userWishlist = await db.UserWishlists.FindAsync(userId);
            if (userWishlist == null)
            {
                db.UserWishlists.Add(
                    new UserWishlist { UserId = userId, ProductIds =  [ productId ] }
                );
                return await Save();
            }
            else
            {
                userWishlist.ProductIds.Add(productId);
                return await Save();
            }
        }

        public async Task<IEnumerable<int>> GetWishlistProductsByUserIdAsync(string userId)
        {
            var userWishlist = await db.UserWishlists.FindAsync(userId);
            return userWishlist?.ProductIds ?? Enumerable.Empty<int>();
        }

        public async Task<bool> RemoveProductFromWishlistAsync(string userId, int productId)
        {
            var userWishlist =
                await db.UserWishlists.FindAsync(userId)
                ?? throw new InvalidDataException("Object doesn't exist.");

            userWishlist.ProductIds.Remove(productId);
            return await Save();
        }

        private async Task<bool> Save()
        {
            var result = await db.SaveChangesAsync();
            return result > 0;
        }
    }
}
