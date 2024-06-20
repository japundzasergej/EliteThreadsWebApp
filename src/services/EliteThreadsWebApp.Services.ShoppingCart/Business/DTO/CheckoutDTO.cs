namespace EliteThreadsWebApp.Services.ShoppingCart.Business.DTO
{
    public record CheckoutDTO
    {
        public string UserId { get; init; }
        public CartDTO CartDTO { get; init; }
        public double TotalPrice { get; init; }
    }
}
