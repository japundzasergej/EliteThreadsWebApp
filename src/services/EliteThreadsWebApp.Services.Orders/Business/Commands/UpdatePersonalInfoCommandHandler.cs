using AutoMapper;
using EliteThreadsWebApp.Services.Orders.Domain;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Repository;
using MediatR;

namespace EliteThreadsWebApp.Services.Orders.Business.Commands
{
    public class UpdatePersonalInfoCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        : IRequestHandler<UpdatePersonalInfoCommand, bool>
    {
        public async Task<bool> Handle(
            UpdatePersonalInfoCommand request,
            CancellationToken cancellationToken
        )
        {
            return await orderRepository.UpdatePersonalInfoAsync(
                mapper.Map<PersonalInfo>(request.DTO)
            );
        }
    }
}
