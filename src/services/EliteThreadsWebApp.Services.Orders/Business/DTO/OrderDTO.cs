namespace EliteThreadsWebApp.Services.Orders.Business.DTO
{
    public record OrderDTO
    {
        public OrderHeaderDTO OrderHeader { get; init; }
        public IEnumerable<OrderDetailDTO> OrderDetails { get; init; }
    }
}
