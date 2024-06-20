namespace EliteThreadsWebApp.Services.Promotions.Business.DTO
{
    public record PromotionsDTO
    {
        public int PromotionId { get; init; }
        public string Message { get; init; }
    }
}
