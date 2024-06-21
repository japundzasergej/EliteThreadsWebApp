namespace EliteThreadsWebApp.Contracts
{
    public record OrderDetail
    {
        public string OrderHeaderId { get; init; }
        public int SelectedSize { get; init; }
        public string SelectedColor { get; init; }
        public int ProductId { get; init; }
        public OrderProduct OrderProduct { get; init; }
        public int Quantity { get; init; }
        public int IndividualPrice { get; init; }
    }
}
