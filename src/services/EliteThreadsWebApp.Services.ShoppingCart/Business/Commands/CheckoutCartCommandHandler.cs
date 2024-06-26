using AutoMapper;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.ShoppingCart.Business.Commands.Helpers;
using EliteThreadsWebApp.Services.ShoppingCart.Business.DTO;
using MassTransit;
using MediatR;

namespace EliteThreadsWebApp.Services.ShoppingCart.Business.Commands
{
    public class CheckoutCartCommandHandler(IMapper mapper, IPublishEndpoint publishEndpoint)
        : IRequestHandler<CheckoutCartCommand, OrderPlacedDTO>
    {
        public async Task<OrderPlacedDTO> Handle(
            CheckoutCartCommand request,
            CancellationToken cancellationToken
        )
        {
            var orderId = $"{Guid.NewGuid()}";
            var orderPlacedEvent = new OrderPlacedEvent
            {
                OrderHeader = new()
                {
                    OrderHeaderId = orderId,
                    TotalPrice = request.DTO.TotalPrice,
                    UserId = request.DTO.UserId
                },
                OrderDetails =  [ ]
            };
            foreach (var detail in request.DTO.CartDTO.CartDetails)
            {
                orderPlacedEvent
                    .OrderDetails
                    .Add(
                        new OrderDetail
                        {
                            IndividualPrice = detail.Product.HasDiscount
                                ? (
                                    CalculateDiscount.Calculate(
                                        detail.Product.Price,
                                        detail.Product.DiscountAmount
                                    )
                                )
                                : (detail.Product.Price),
                            OrderHeaderId = orderPlacedEvent.OrderHeader.OrderHeaderId,
                            ProductId = detail.Product.ProductId,
                            OrderProduct = mapper.Map<OrderProduct>(detail.Product),
                            Quantity = detail.Quantity,
                            SelectedColor = detail.SelectedColor,
                            SelectedSize = detail.SelectedSize,
                        }
                    );
            }
            await publishEndpoint.Publish(orderPlacedEvent);
            return new OrderPlacedDTO { OrderId = orderPlacedEvent.OrderHeader.OrderHeaderId };
        }
    }
}
