using EliteThreadsWebApp.Services.ShoppingCart.Domain;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.ShoppingCart.Infrastructure.Repository
{
    public class ShoppingCartRepository(ApplicationDbContext db) : IShoppingCartRepository
    {
        public async Task<bool> ClearCartAsync(string userId)
        {
            var userHeader = await db.CartHeaders.FirstOrDefaultAsync(u => u.UserId == userId);
            if (userHeader != null)
            {
                db.CartDetails.RemoveRange(
                    db.CartDetails.Where(u => u.CartHeaderId == userHeader.CartHeaderId)
                );
                db.CartHeaders.Remove(userHeader);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task CreateUpdateCartAsync(Cart cart)
        {
            var dbProduct = await db.Products.FirstOrDefaultAsync(
                p => p.ProductId == cart.CartDetails.FirstOrDefault().ProductId
            );
            if (dbProduct == null)
            {
                db.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await db.SaveChangesAsync();
            }
            var userCartHeader = await db.CartHeaders
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);
            if (userCartHeader == null)
            {
                db.CartHeaders.Add(cart.CartHeader);
                await db.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Product = null;
                db.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await db.SaveChangesAsync();
            }
            else
            {
                var cartDetailsDb = await db.CartDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(
                        c =>
                            c.ProductId == cart.CartDetails.FirstOrDefault().ProductId
                            && c.CartHeaderId == userCartHeader.CartHeaderId
                    );
                if (cartDetailsDb == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = userCartHeader.CartHeaderId;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    db.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await db.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Quantity += cartDetailsDb.Quantity;
                    cart.CartDetails.FirstOrDefault().CartDetailId = cartDetailsDb.CartDetailId;
                    cart.CartDetails.First().CartHeaderId = userCartHeader.CartHeaderId;

                    db.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            Cart cart =
                new()
                {
                    CartHeader = await db.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId)
                };
            cart.CartDetails = db.CartDetails
                .Where(c => c.CartHeaderId == cart.CartHeader.CartHeaderId)
                .Include(c => c.Product);
            return cart;
        }

        public async Task<bool> RemoveFromCartAsync(int cartDetailsId)
        {
            var userDetails =
                await db.CartDetails.FirstOrDefaultAsync(u => u.CartDetailId == cartDetailsId)
                ?? throw new InvalidDataException("Non-existent cart detail.");
            int totalCountOfItems = db.CartDetails
                .Where(c => c.CartHeaderId == userDetails.CartHeaderId)
                .Count();

            db.Remove(userDetails);
            if (totalCountOfItems == 1)
            {
                var header = await db.CartHeaders.FirstOrDefaultAsync(
                    u => u.CartHeaderId == userDetails.CartHeaderId
                );
                db.CartHeaders.Remove(header);
            }
            await db.SaveChangesAsync();
            return true;
        }
    }
}
