using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.Social.Domain.Entities
{
    public record Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; init; }

        [Range(1, 5)]
        public float Rating { get; set; } = 0;
        public int TotalRatingCount { get; set; } = 0;
        public float TotalRatingSum { get; set; } = 0;
        public int OneStarRating { get; set; } = 0;
        public int TwoStarRating { get; set; } = 0;
        public int ThreeStarRating { get; set; } = 0;
        public int FourStarRating { get; set; } = 0;
        public int FiveStarRating { get; set; } = 0;
    }
}
