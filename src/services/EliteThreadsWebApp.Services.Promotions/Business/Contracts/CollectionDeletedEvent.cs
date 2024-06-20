namespace EliteThreadsWebApp.Contracts
{
    public record CollectionDeletedEvent
    {
        public List<int> ProductIds { get; init; }
    }
}
