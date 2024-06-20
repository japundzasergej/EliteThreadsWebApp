namespace EliteThreadsWebApp.Services.ShoppingCart.Business.DTO
{
    public record CartHeaderDTO
    {
        public int CartHeaderId { get; init; }
        public string UserId { get; init; }
    }
}
