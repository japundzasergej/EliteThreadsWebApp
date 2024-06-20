using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class CreatePromotionMessageCommandHandler(IPromotionsRepository promotionsRepository)
        : IRequestHandler<CreatePromotionMessageCommand, bool>
    {
        public async Task<bool> Handle(
            CreatePromotionMessageCommand request,
            CancellationToken cancellationToken
        )
        {
            return await promotionsRepository.CreatePromotionMessageAsync(request.DTO.Message);
        }
    }
}
