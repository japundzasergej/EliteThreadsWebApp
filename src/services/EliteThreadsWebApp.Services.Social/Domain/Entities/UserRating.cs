using System.ComponentModel.DataAnnotations;

namespace EliteThreadsWebApp.Services.Social.Domain.Entities
{
    public record UserRating
    {
        [Key]
        public int RatingId { get; set; }
        public string UserId { get; init; }
        public int ProductId { get; init; }
        public float UserInput { get; set; }
    }
}
