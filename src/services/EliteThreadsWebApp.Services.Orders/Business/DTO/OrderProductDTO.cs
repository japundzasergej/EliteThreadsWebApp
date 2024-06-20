namespace EliteThreadsWebApp.Services.Orders.Business.DTO
{
    public record OrderProductDTO
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public string Image { get; init; }
    }
}
