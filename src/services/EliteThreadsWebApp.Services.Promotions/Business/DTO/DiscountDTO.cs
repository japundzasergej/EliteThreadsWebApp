namespace EliteThreadsWebApp.Services.Promotions.Business.DTO
{
    public record DiscountDTO
    {
        public int DiscountId { get; init; }
        public string DiscountName { get; init; }
        public int DiscountAmount { get; init; }
    }
}
