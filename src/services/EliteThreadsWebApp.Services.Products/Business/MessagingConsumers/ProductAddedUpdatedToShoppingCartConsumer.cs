using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Products.Business.MessagingConsumers
{
    public class ProductAddedUpdatedToShoppingCartConsumer(
        IPublishEndpoint publishEndpoint,
        IProductRepository productRepository,
        IMapper mapper
    ) : IConsumer<ProductAddedToShoppingCartEvent>
    {
        public async Task Consume(ConsumeContext<ProductAddedToShoppingCartEvent> context)
        {
            ProductAddedToShoppingCartEvent message = context.Message;
            var product = await productRepository.GetProductByIdAsync(message.ProductId);

            await publishEndpoint.Publish(
                new ShoppingCartPopulatedEvent
                {
                    PopulatedHeader = mapper.Map<PopulatedHeader>(message),
                    PopulatedDetails = mapper.Map<PopulatedDetails>(product)
                }
            );
        }
    }
}
