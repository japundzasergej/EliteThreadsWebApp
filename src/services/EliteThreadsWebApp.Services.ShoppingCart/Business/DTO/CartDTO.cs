namespace EliteThreadsWebApp.Services.ShoppingCart.Business.DTO
{
    public record CartDTO
    {
        public CartHeaderDTO CartHeader { get; init; }
        public IEnumerable<CartDetailDTO> CartDetails { get; init; }
    }
}
