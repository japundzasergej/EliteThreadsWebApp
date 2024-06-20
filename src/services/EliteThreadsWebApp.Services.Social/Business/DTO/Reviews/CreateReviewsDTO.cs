namespace EliteThreadsWebApp.Services.Social.Business.DTO.Reviews
{
    public record CreateReviewsDTO
    {
        public string UserId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedDate { get; init; }
        public int ProductId { get; set; }
    }
}
