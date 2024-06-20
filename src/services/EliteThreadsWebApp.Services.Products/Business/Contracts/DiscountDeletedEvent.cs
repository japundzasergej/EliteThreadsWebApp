namespace EliteThreadsWebApp.Contracts
{
    public record DiscountDeletedEvent
    {
        public List<int> ProductIds { get; init; }
    }
}
