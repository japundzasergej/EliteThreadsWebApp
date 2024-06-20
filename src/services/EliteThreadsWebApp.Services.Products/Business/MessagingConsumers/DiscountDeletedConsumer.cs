using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Products.Business.MessagingConsumers
{
    public class DiscountDeletedConsumer(IProductRepository productRepository)
        : IConsumer<DiscountDeletedEvent>
    {
        public async Task Consume(ConsumeContext<DiscountDeletedEvent> context)
        {
            DiscountDeletedEvent message = context.Message;
            await productRepository.OnDiscountDeletedAsync([ .. message.ProductIds ]);
        }
    }
}
