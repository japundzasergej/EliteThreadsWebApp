namespace EliteThreadsWebApp.Contracts
{
    public record DiscountChangedEvent
    {
        public int ProductId { get; init; }
        public int? DiscountId { get; init; }
        public string? DiscountName { get; init; }
        public int? DiscountAmount { get; init; }
    }
}
