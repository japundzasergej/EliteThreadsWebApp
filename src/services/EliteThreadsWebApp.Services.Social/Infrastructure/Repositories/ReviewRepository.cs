using EliteThreadsWebApp.Services.Social.Domain.Entities;
using EliteThreadsWebApp.Services.Social.Infrastructure.Helpers;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace EliteThreadsWebApp.Services.Social.Infrastructure.Repositories
{
    public class ReviewRepository(ApplicationDbContext db) : IReviewRepository
    {
        public async Task<Product> GetProductRatingsByIdAsync(int productId)
        {
            var productFromDb = await db.Products.FirstOrDefaultAsync(
                p => p.ProductId == productId
            );
            if (productFromDb == null)
            {
                var newProduct = db.Products.Add(new Product { ProductId = productId });
                await db.SaveChangesAsync();
                return newProduct.Entity;
            }
            return productFromDb;
        }

        public async Task<UserRating?> GetUserRatingAsync(int productId, string userId)
        {
            return await db.UserRatings.FirstOrDefaultAsync(
                r => r.ProductId == productId && r.UserId == userId
            );
        }

        public async Task<bool> CreateReviewAsync(
            Review review,
            string userName,
            string profilePicture
        )
        {
            var productFromDb = db.Products.FirstOrDefault(p => p.ProductId == review.ProductId);
            if (productFromDb == null)
            {
                db.Add(new Product { ProductId = review.ProductId, });
                await db.SaveChangesAsync();
            }
            review.UserName = userName;
            review.ProfilePicture = profilePicture;
            db.Add(review);
            return await Save();
        }

        public async Task<bool> CreateUserRatingAsync(UserRating userRating)
        {
            var existingRating = await db.UserRatings
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    r => r.UserId == userRating.UserId && r.ProductId == userRating.ProductId
                );

            if (existingRating == null)
            {
                var newRating = db.Add(userRating);
                await UpdateProductRatingAsync(userRating, false);
                return await Save();
            }
            else
            {
                userRating.RatingId = existingRating.RatingId;
                var updatedRating = db.Update(userRating);
                await UpdateProductRatingAsync(userRating, true, existingRating.UserInput);
                return await Save();
            }
        }

        public async Task<bool> DeleteReviewAsync(Review review)
        {
            db.Remove(review);
            return await Save();
        }

        public async Task<bool> EditReviewAsync(Review review)
        {
            review.IsEdited = true;
            db.Update(review);
            return await Save();
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await db.Reviews.FirstOrDefaultAsync(r => r.ReviewId == reviewId)
                ?? throw new InvalidDataException("Object doesn't exist");
        }

        public async Task<Review> GetReviewByIdNoTrackAsync(int reviewId)
        {
            return await db.Reviews.AsNoTracking().FirstOrDefaultAsync(r => r.ReviewId == reviewId)
                ?? throw new InvalidDataException("Object doesn't exist");
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int productId)
        {
            return await db.Reviews.Where(r => r.ProductId == productId).ToListAsync() ?? [ ];
        }

        private async Task UpdateProductRatingAsync(
            UserRating rating,
            bool ratingExists,
            float? existingRating = null
        )
        {
            var product = await db.Products.FindAsync(rating.ProductId);

            if (product == null)
            {
                var newProduct = await db.Products.AddAsync(
                    new Product { ProductId = rating.ProductId }
                );
                UpdateProductRating.Update(newProduct.Entity, rating.UserInput, true);
            }
            else
            {
                UpdateProductRating.Update(
                    product,
                    rating.UserInput,
                    !ratingExists,
                    existingRating
                );
            }
        }

        private async Task<bool> Save()
        {
            var result = await db.SaveChangesAsync();
            return result > 0;
        }
    }
}
