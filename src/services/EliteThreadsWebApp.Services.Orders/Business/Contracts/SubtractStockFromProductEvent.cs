namespace EliteThreadsWebApp.Contracts
{
    public record SubtractStockFromProductEvent
    {
        public List<SubtractedProduct> SubtractedProducts { get; init; }
    }
}
