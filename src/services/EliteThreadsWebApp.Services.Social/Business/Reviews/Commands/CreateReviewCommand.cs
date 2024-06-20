using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class CreateReviewCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public CreateReviewsDTO ReviewsDTO { get; set; }
    }
}
