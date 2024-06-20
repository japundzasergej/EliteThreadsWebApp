using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class CreatePromotionMessageCommand : IRequest<bool>
    {
        public CreatePromotionDTO DTO { get; init; }
    }
}
