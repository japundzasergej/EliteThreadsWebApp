using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Orders.Domain;
using EliteThreadsWebApp.Services.Orders.Infrastructure.Repository;
using MassTransit;

namespace EliteThreadsWebApp.Services.Orders.Business.MessagingConsumers
{
    public class OrderPlacedConsumer(IMapper mapper, IOrderRepository orderRepository)
        : IConsumer<OrderPlacedEvent>
    {
        public async Task Consume(ConsumeContext<OrderPlacedEvent> context)
        {
            var message = context.Message;
            await orderRepository.CreateOrderAsync(mapper.Map<Order>(message));
        }
    }
}
