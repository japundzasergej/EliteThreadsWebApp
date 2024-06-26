using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Payment.Business.DTO;
using MassTransit;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace EliteThreadsWebApp.Services.Payment.Stripe
{
    public class StripeService : IStripeService
    {
        private readonly IOptions<StripeSettings> _stripeSettings;
        private readonly IPublishEndpoint _publishEndpoint;

        public StripeService(
            IOptions<StripeSettings> stripeSettings,
            IPublishEndpoint publishEndpoint
        )
        {
            _stripeSettings = stripeSettings;
            _publishEndpoint = publishEndpoint;
            StripeConfiguration.ApiKey = stripeSettings.Value.SecretKey;
        }

        public async Task<StripeCheckoutResponse> Checkout(OrderDTO order)
        {
            var sessionId = await CreateSessionString(order);

            return new StripeCheckoutResponse
            {
                SessionId = sessionId,
                PubKey = _stripeSettings.Value.PublishableKey
            };
        }

        public async Task<bool> HandleSuccess(string orderHeaderId)
        {
            await _publishEndpoint.Publish(
                new PaymentSucceededEvent { OrderHeaderId = orderHeaderId }
            );
            return true;
        }

        private async Task<string> CreateSessionString(OrderDTO order)
        {
            var options = new SessionCreateOptions
            {
                SuccessUrl =
                    $"{_stripeSettings.Value.ApiUrl}/checkout/success?sessionId="
                    + "{CHECKOUT_SESSION_ID}"
                    + "&orderHeaderId="
                    + order.OrderHeader.OrderHeaderId,
                CancelUrl =
                    _stripeSettings.Value.ClientUrl
                    + $"/payment-failed?orderHeaderId={order.OrderHeader.OrderHeaderId}",
                PaymentMethodTypes =  [ "card" ],
                LineItems =  [ ],
                Mode = "payment"
            };
            foreach (var orderDetails in order.OrderDetails)
            {
                options
                    .LineItems
                    .Add(
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmount = Convert.ToInt64((orderDetails.IndividualPrice) * 100),
                                Currency = "EUR",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = orderDetails.OrderProduct.ProductName,
                                    Images =  [ orderDetails.OrderProduct.Image ]
                                },
                            },
                            Quantity = orderDetails.Quantity
                        }
                    );
            }
            options
                .LineItems
                .Add(
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = 3000,
                            Currency = "EUR",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Shipping Cost"
                            }
                        },
                        Quantity = 1
                    }
                );
            var service = new SessionService();
            var session = await service.CreateAsync(options);
            return session.Id;
        }
    }
}
