namespace EliteThreadsWebApp.Services.Promotions.Infrastructure
{
    public record OnDeletion
    {
        public bool IsSuccessful { get; init; }
        public IEnumerable<int> ProductIds { get; init; }
    }
}
