namespace EliteThreadsWebApp.Services.Orders.Domain
{
    public record Order
    {
        public OrderHeaderEntity OrderHeader { get; init; }
        public IEnumerable<OrderDetailEntity> OrderDetails { get; init; }
    }
}
