using EliteThreadsWebApp.Services.Social.Business.Helpers;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class DeleteReviewCommandHandler(IReviewRepository reviewRepository)
        : IRequestHandler<DeleteReviewCommand, bool>
    {
        public async Task<bool> Handle(
            DeleteReviewCommand request,
            CancellationToken cancellationToken
        )
        {
            return await reviewRepository.DeleteReviewAsync(
                await reviewRepository.GetReviewByIdAsync((int)request.ReviewId)
                    ?? throw new InvalidDataException("Object doesn't exist.")
            );
        }
    }
}
