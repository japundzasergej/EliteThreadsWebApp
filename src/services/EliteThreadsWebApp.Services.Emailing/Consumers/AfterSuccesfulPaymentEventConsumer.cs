using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Emailing.SendGrid;
using MassTransit;

namespace EliteThreadsWebApp.Services.Emailing.Consumers
{
    public class AfterSuccessfulPaymentEventConsumer(ISendGridService sendGridService)
        : IConsumer<AfterSuccessfulPaymentEvent>
    {
        public async Task Consume(ConsumeContext<AfterSuccessfulPaymentEvent> context)
        {
            await sendGridService.SendAsync(context.Message);
        }
    }
}
