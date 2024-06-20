namespace EliteThreadsWebApp.Services.Social.Business.DTO.Reviews
{
    public class ReviewsDTO
    {
        public int ReviewId { get; init; }
        public string UserId { get; init; }
        public string ProfilePicture { get; init; }
        public string UserName { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime CreatedDate { get; init; }
        public bool IsEdited { get; init; }
        public int ProductId { get; init; }
    }
}
