using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class EditReviewCommand : IRequest<bool>
    {
        public int? ReviewId { get; set; }
        public EditReviewDTO ReviewsDTO { get; set; }
    }
}
