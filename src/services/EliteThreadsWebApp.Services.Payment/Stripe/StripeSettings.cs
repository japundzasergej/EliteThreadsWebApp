namespace EliteThreadsWebApp.Services.Payment.Stripe
{
    public record StripeSettings
    {
        public string PublishableKey { get; init; }
        public string SecretKey { get; init; }
        public string ApiUrl { get; init; }
        public string ClientUrl { get; init; }
    }
}
