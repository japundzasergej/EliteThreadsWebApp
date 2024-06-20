namespace EliteThreadsWebApp.Services.Promotions.Business.DTO
{
    public record CreateDiscountDTO
    {
        public string DiscountName { get; init; }
        public int DiscountAmount { get; init; }
    }
}
