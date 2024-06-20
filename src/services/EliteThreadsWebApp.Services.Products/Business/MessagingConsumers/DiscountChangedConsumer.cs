using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Products.Business.MessagingConsumers
{
    public class DiscountChangedConsumer(IProductRepository productRepository)
        : IConsumer<DiscountChangedEvent>
    {
        public async Task Consume(ConsumeContext<DiscountChangedEvent> context)
        {
            DiscountChangedEvent message = context.Message;
            await productRepository.OnDiscountChangedAsync(
                message.ProductId,
                message.DiscountId,
                message.DiscountName,
                message.DiscountAmount
            );
        }
    }
}
