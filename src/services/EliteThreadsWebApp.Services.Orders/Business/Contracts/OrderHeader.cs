namespace EliteThreadsWebApp.Contracts
{
    public record OrderHeader
    {
        public string OrderHeaderId { get; init; }
        public string UserId { get; init; }
        public double TotalPrice { get; init; }
    }
}
