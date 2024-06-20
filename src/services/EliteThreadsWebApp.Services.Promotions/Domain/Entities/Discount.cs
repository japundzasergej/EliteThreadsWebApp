using System.ComponentModel.DataAnnotations;

namespace EliteThreadsWebApp.Services.Promotions.Domain.Entities
{
    public record Discount
    {
        [Key]
        public int DiscountId { get; init; }
        public string DiscountName { get; init; }
        public int DiscountAmount { get; set; }
    }
}
