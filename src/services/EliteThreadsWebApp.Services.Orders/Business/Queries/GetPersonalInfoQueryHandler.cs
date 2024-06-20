using AutoMapper;
using EliteThreadsWebApp.Services.Orders.Business.DTO;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Queries
{
    public class GetPersonalInfoQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        : IRequestHandler<GetPersonalInfoQuery, PersonalInfoDTO>
    {
        public async Task<PersonalInfoDTO> Handle(
            GetPersonalInfoQuery request,
            CancellationToken cancellationToken
        )
        {
            return mapper.Map<PersonalInfoDTO>(
                await orderRepository.GetPersonalInfoAsync(request.UserId)
            );
        }
    }
}
