namespace EliteThreadsWebApp.Contracts
{
    public record CollectionChangedEvent
    {
        public int ProductId { get; init; }
        public int? CollectionId { get; init; }
        public string? CollectionName { get; init; }
    }
}
