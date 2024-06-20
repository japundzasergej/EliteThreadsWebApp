namespace EliteThreadsWebApp.Contracts
{
    public record RatingChangedEvent
    {
        public int ProductId { get; init; }
        public float Rating { get; init; }
        public int TotalRatingCount { get; init; }
    }
}
