using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Products.Business.MessagingConsumers
{
    public class CollectionDeletedConsumer(IProductRepository productRepository)
        : IConsumer<CollectionDeletedEvent>
    {
        public async Task Consume(ConsumeContext<CollectionDeletedEvent> context)
        {
            CollectionDeletedEvent message = context.Message;
            await productRepository.OnCollectionDeletedAsync([ .. message.ProductIds ]);
        }
    }
}
