using AutoMapper;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class EditReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        : IRequestHandler<EditReviewCommand, bool>
    {
        public async Task<bool> Handle(
            EditReviewCommand request,
            CancellationToken cancellationToken
        )
        {
            var reviewFromDb =
                await reviewRepository.GetReviewByIdNoTrackAsync((int)request.ReviewId)
                ?? throw new InvalidDataException("Object doesn't exist");
            var reviewToUpdate = mapper.Map(request.ReviewsDTO, reviewFromDb);
            return await reviewRepository.EditReviewAsync(reviewToUpdate);
        }
    }
}
