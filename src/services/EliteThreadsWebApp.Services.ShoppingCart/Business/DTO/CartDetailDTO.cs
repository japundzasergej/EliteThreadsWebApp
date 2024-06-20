namespace EliteThreadsWebApp.Services.ShoppingCart.Business.DTO
{
    public record CartDetailDTO
    {
        public int CartDetailId { get; init; }
        public int CartHeaderId { get; init; }
        public virtual CartHeaderDTO CartHeader { get; init; }
        public int ProductId { get; init; }
        public virtual ProductDTO Product { get; init; }
        public int Quantity { get; init; }
        public string SelectedColor { get; init; }
        public int SelectedSize { get; init; }
    }
}
