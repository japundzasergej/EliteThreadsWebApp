using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EliteThreadsWebApp.Services.ShoppingCart.Domain
{
    public record Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public string Image { get; init; }
        public double Price { get; init; }
        public double? PriceAfterDiscount { get; init; }
        public bool HasDiscount { get; init; }
        public int DiscountAmount { get; init; }
    }
}
