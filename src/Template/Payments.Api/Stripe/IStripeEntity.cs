namespace Payments.Api.Stripe;

internal interface IStripeEntity
{
    public StripeId StripeId { get; init; }
}