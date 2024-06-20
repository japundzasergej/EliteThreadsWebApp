using System.ComponentModel.DataAnnotations;

namespace EliteThreadsWebApp.Services.ShoppingCart.Domain
{
    public record CartHeader
    {
        [Key]
        public int CartHeaderId { get; init; }
        public string UserId { get; init; }
    }
}
