using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Products.Business.MessagingConsumers
{
    public class RatingChangedConsumer(IProductRepository productRepository)
        : IConsumer<RatingChangedEvent>
    {
        public async Task Consume(ConsumeContext<RatingChangedEvent> context)
        {
            var message = context.Message;
            await productRepository.OnRatingChangedAsync(
                message.ProductId,
                message.Rating,
                message.TotalRatingCount
            );
        }
    }
}
