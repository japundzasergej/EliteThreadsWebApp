namespace EliteThreadsWebApp.Services.Social.Business.DTO.Reviews
{
    public record UserRatingDTO
    {
        public string UserId { get; init; }
        public int ProductId { get; init; }
        public float UserInput { get; init; }
    }
}
