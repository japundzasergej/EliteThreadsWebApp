namespace EliteThreadsWebApp.Contracts
{
    public record ProductAddedToShoppingCartEvent
    {
        public int ProductId { get; init; }
        public string UserId { get; init; }
        public string SelectedColor { get; init; }
        public int SelectedSize { get; init; }
        public int Quantity { get; init; }
    }
}
