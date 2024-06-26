namespace EliteThreadsWebApp.Services.ShoppingCart.Business.DTO
{
    public record ProductDTO
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public string Image { get; init; }
        public double Price { get; init; }
        public double? PriceAfterDiscount { get; init; }
        public bool HasDiscount { get; init; }
        public int DiscountAmount { get; init; }
        public int ProductsLeft { get; init; }
    }
}
