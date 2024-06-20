namespace EliteThreadsWebApp.Services.ShoppingCart.Domain
{
    public record Cart
    {
        public CartHeader CartHeader { get; init; }
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
