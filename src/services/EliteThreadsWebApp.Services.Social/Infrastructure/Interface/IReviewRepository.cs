using EliteThreadsWebApp.Services.Social.Domain.Entities;

namespace EliteThreadsWebApp.Services.Social.Infrastructure.Interface
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsAsync(int productId);
        Task<Product> GetProductRatingsByIdAsync(int productId);
        Task<UserRating?> GetUserRatingAsync(int productId, string userId);
        Task<Review> GetReviewByIdAsync(int reviewId);
        Task<Review> GetReviewByIdNoTrackAsync(int reviewId);
        Task<bool> CreateUserRatingAsync(UserRating userRating);
        Task<bool> CreateReviewAsync(Review review, string userName, string profilePicture);
        Task<bool> EditReviewAsync(Review review);
        Task<bool> DeleteReviewAsync(Review review);
    }
}
