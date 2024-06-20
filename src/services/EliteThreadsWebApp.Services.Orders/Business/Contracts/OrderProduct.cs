namespace EliteThreadsWebApp.Contracts
{
    public record OrderProduct
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public string Image { get; init; }
    }
}
