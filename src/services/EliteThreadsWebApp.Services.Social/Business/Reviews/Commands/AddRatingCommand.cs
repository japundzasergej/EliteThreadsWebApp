using EliteThreadsWebApp.Services.Social.Business.DTO.Reviews;
using MediatR;

namespace EliteThreadsWebApp.Services.Social.Business.Reviews.Commands
{
    public class AddRatingCommand : IRequest<bool>
    {
        public UserRatingDTO DTO { get; init; }
    }
}
