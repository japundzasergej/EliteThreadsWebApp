namespace EliteThreadsWebApp.Contracts
{
    public record SubtractStockFromProductEvent
    {
        public List<int> ProductIds { get; init; }
    }
}
