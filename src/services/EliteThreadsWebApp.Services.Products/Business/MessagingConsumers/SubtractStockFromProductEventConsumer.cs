using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Products.Domain;
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
            var products = new List<SubtractQuantityFromProduct>();
            foreach (var product in message.SubtractedProducts)
            {
                products.Add(
                    new SubtractQuantityFromProduct
                    {
                        ProductId = product.ProductId,
                        Quantity = product.Quantity,
                    }
                );
            }
            await productRepository.OnSuccessfulPayment(products);
        }
    }
}
