namespace EliteThreadsWebApp.Contracts
{
    public record PopulatedHeader
    {
        public string UserId { get; init; }
        public int Quantity { get; init; }
        public string SelectedColor { get; init; }
        public int SelectedSize { get; init; }
    }
}
