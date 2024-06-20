using AutoMapper;
using EliteThreadsWebApp.Contracts;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class CreateUpdateCartCommandHandler(IPublishEndpoint publishEndpoint, IMapper mapper)
        : IRequestHandler<CreateUpdateCartCommand, bool>
    {
        public async Task<bool> Handle(
            CreateUpdateCartCommand request,
            CancellationToken cancellationToken
        )
        {
            await publishEndpoint.Publish(mapper.Map<ProductAddedToShoppingCartEvent>(request.DTO));
            return true;
        }
    }
}
