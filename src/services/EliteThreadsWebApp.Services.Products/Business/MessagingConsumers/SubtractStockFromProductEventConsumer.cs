using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Products.Business.MessagingConsumers
{
    public class SubtractStockFromProductEventConsumer(IProductRepository productRepository)
        : IConsumer<SubtractStockFromProductEvent>
    {
        public async Task Consume(ConsumeContext<SubtractStockFromProductEvent> context)
        {
            var message = context.Message;
            await productRepository.OnSuccessfulPayment([ .. message.ProductIds ]);
        }
    }
}
