using System.ComponentModel.DataAnnotations;

namespace EliteThreadsWebApp.Services.Promotions.Domain.Entities
{
    public record ActivePromotions
    {
        [Key]
        public int PromotionId { get; init; }
        public string Message { get; init; }
    }
}
