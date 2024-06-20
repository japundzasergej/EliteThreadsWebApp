using AutoMapper;
using EliteThreadsWebApp.Services.Promotions.Business.DTO;
using EliteThreadsWebApp.Services.Promotions.Domain.Entities;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Queries
{
    public class GetActiveDiscountsQueryHandler(
        IPromotionsRepository promotionsRepository,
        IMapper mapper
    ) : IRequestHandler<GetActiveDiscountsQuery, IEnumerable<DiscountDTO>>
    {
        public async Task<IEnumerable<DiscountDTO>> Handle(
            GetActiveDiscountsQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await promotionsRepository.GetActiveDiscountsAsync();
            if (!result.Any())
            {
                return [ ];
            }
            return result.Select(mapper.Map<DiscountDTO>);
        }
    }
}
