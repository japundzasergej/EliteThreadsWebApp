namespace EliteThreadsWebApp.Contracts
{
    public record ShoppingCartPopulatedEvent
    {
        public PopulatedHeader PopulatedHeader { get; init; }
        public PopulatedDetails PopulatedDetails { get; init; }
    }
}
