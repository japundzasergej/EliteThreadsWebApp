using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.ShoppingCart.Domain;
using EliteThreadsWebApp.Services.ShoppingCart.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.MessagingConsumers
{
    public class ShoppingCartPopulatedConsumer(
        IShoppingCartRepository shoppingCartRepository,
        IMapper mapper
    ) : IConsumer<ShoppingCartPopulatedEvent>
    {
        public async Task Consume(ConsumeContext<ShoppingCartPopulatedEvent> context)
        {
            var message = context.Message;
            var product = mapper.Map<Product>(message.PopulatedDetails);

            await shoppingCartRepository.CreateUpdateCartAsync(
                new()
                {
                    CartHeader = new() { UserId = message.PopulatedHeader.UserId, },
                    CartDetails =
                    [
                        new() {
                    Quantity = message.PopulatedHeader.Quantity,
                    ProductId = message.PopulatedDetails.ProductId,
                    Product = product,
                    SelectedColor = message.PopulatedHeader.SelectedColor,
                    SelectedSize = message.PopulatedHeader.SelectedSize
                }
                    ]
                }
            );
        }
    }
}
