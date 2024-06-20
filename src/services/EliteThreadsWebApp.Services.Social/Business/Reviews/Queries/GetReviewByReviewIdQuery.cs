using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetReviewByReviewIdQuery : IRequest<ReviewsDTO>
    {
        public int ReviewId { get; set; }
    }
}
