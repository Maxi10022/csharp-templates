namespace Payments.Api.Stripe.Options;

internal sealed class StripeOptions
{
    public string ApiKey { get; init; }
    
    public string WebhookSecret { get; init; }
}