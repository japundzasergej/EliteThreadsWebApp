using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public int? ReviewId { get; set; }
    }
}
