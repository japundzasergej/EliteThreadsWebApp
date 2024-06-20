namespace EliteThreadsWebApp.Contracts
{
    public record OrderPlacedEvent
    {
        public OrderHeader OrderHeader { get; init; }
        public List<OrderDetail> OrderDetails { get; init; }
    }
}
