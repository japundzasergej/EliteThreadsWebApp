using EliteThreadsWebApp.Services.Payment.Business.DTO;

namespace EliteThreadsWebApp.Services.Payment.Stripe
{
    public interface IStripeService
    {
        Task<StripeCheckoutResponse> Checkout(OrderDTO orderDTO);
        Task<bool> HandleSuccess(string orderHeaderId);
    }
}
