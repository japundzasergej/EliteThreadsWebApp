namespace EliteThreadsWebApp.Contracts
{
    public record PaymentSucceededEvent
    {
        public string OrderHeaderId { get; init; }
    }
}
