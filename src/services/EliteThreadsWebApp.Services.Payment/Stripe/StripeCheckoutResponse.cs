namespace EliteThreadsWebApp.Services.Payment.Stripe
{
    public record StripeCheckoutResponse
    {
        public string? SessionId { get; init; }
        public string? PubKey { get; set; }
    }
}
