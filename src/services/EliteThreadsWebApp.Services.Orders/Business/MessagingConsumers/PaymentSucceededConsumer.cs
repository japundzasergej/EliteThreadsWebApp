using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Orders.Business.MessagingConsumers
{
    public class PaymentSucceededConsumer(
        IOrderRepository orderRepository,
        IPublishEndpoint publishEndpoint,
        IMapper mapper
    ) : IConsumer<PaymentSucceededEvent>
    {
        public async Task Consume(ConsumeContext<PaymentSucceededEvent> context)
        {
            var message = context.Message;

            await orderRepository.UpdatePaymentStatusAsync(message.OrderHeaderId);
            var order = await orderRepository.GetOrderAsync(message.OrderHeaderId);

            var subtractEvent = new SubtractStockFromProductEvent { SubtractedProducts =  [ ] };

            foreach (var detail in order.OrderDetails)
            {
                subtractEvent
                    .SubtractedProducts
                    .Add(
                        new SubtractedProduct
                        {
                            ProductId = detail.ProductId,
                            Quantity = detail.Quantity
                        }
                    );
            }

            await publishEndpoint.Publish(
                new AfterSuccessfulPaymentEvent
                {
                    OrderHeader = mapper.Map<OrderHeader>(order.OrderHeader),
                    OrderDetails = order.OrderDetails.Select(mapper.Map<OrderDetail>)
                }
            );

            await publishEndpoint.Publish(subtractEvent);
        }
    }
}
