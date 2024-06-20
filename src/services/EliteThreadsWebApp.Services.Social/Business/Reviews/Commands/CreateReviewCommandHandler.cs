using AutoMapper;
using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using EliteThreadsWebApp.Services.Social.Domain.Entities;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class CreateReviewCommandHandler(
        IReviewRepository reviewRepository,
        IMapper mapper,
        IAuth0ManagementService auth0ManagementService
    ) : IRequestHandler<CreateReviewCommand, bool>
    {
        public async Task<bool> Handle(
            CreateReviewCommand request,
            CancellationToken cancellationToken
        )
        {
            var client = await auth0ManagementService.GetManagementApiClient();
            var user =
                await client.Users.GetAsync(request.ReviewsDTO.UserId)
                ?? throw new InvalidDataException("User doesn't exist.");

            request.ReviewsDTO.ProductId = request.ProductId;
            return await reviewRepository.CreateReviewAsync(
                mapper.Map<Review>(request.ReviewsDTO),
                user.UserName,
                user.Picture
            );
        }
    }
}
