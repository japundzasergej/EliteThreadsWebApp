using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Queries
{
    public class GetReviewsByProductIdQuery : IRequest<List<ReviewsDTO>>
    {
        public int? ProductId { get; set; }
    }
}
