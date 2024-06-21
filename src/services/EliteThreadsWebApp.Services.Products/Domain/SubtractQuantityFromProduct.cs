namespace EliteThreadsWebApp.Services.Products.Domain
{
    public record SubtractQuantityFromProduct
    {
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
