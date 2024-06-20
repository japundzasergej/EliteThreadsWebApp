using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Products.Business.MessagingConsumers
{
    public class CollectionChangedConsumer(IProductRepository productRepository)
        : IConsumer<CollectionChangedEvent>
    {
        public async Task Consume(ConsumeContext<CollectionChangedEvent> context)
        {
            CollectionChangedEvent message = context.Message;
            await productRepository.OnCollectionChangedAsync(
                message.ProductId,
                message.CollectionId,
                message.CollectionName
            );
        }
    }
}
