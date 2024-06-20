using AutoMapper;
using EliteThreadsWebApp.Services.Promotions.Domain.Entities;
using EliteThreadsWebApp.Services.Promotions.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Promotions.Business.Commands
{
    public class CreateDiscountCommandHandler(
        IPromotionsRepository promotionsRepository,
        IMapper mapper
    ) : IRequestHandler<CreateDiscountCommand, bool>
    {
        public async Task<bool> Handle(
            CreateDiscountCommand request,
            CancellationToken cancellationToken
        )
        {
            return await promotionsRepository.CreateDiscountAsync(
                mapper.Map<Discount>(request.DiscountDTO)
            );
        }
    }
}
