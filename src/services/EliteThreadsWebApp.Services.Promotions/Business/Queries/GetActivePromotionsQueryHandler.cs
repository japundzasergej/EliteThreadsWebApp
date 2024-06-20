using AutoMapper;
using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MassTransit.Initializers;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Queries
{
    public class GetActivePromotionsQueryHandler(
        IPromotionsRepository promotionsRepository,
        IMapper mapper
    ) : IRequestHandler<GetActivePromotionsQuery, IEnumerable<PromotionsDTO>>
    {
        public async Task<IEnumerable<PromotionsDTO>> Handle(
            GetActivePromotionsQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await promotionsRepository.GetActivePromotionMessagesAsync();
            if (!result.Any())
            {
                return [ ];
            }
            return result.Select(mapper.Map<PromotionsDTO>);
        }
    }
}
