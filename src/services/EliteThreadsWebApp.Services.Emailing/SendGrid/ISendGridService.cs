using EliteThreadsWebApp.Contracts;

namespace EliteThreadsWebApp.Services.Emailing.SendGrid
{
    public interface ISendGridService
    {
        Task SendAsync(AfterSuccessfulPaymentEvent paymentEvent);
    }
}
