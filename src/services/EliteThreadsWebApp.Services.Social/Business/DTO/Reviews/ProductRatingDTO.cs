using System.ComponentModel.DataAnnotations;

namespace EliteThreadsWebApp.Services.Social.Business.DTO.Reviews
{
    public record ProductRatingDTO
    {
        public int ProductId { get; init; }
        public float Rating { get; init; }
        public int TotalRatingCount { get; init; }
        public float TotalRatingSum { get; init; }
        public int OneStarRating { get; init; }
        public int TwoStarRating { get; init; }
        public int ThreeStarRating { get; init; }
        public int FourStarRating { get; init; }
        public int FiveStarRating { get; init; }
    }
}
