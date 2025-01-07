namespace Payments.Api.Prices.Components;

/// <summary>
/// Only required if a default tax behavior was not provided in the Stripe Tax settings.
/// Specifies whether the price is considered <c>inclusive</c> of taxes or <c>exclusive</c> of taxes.
/// One of <c>inclusive</c>, <c>exclusive</c>, or <c>unspecified</c>.
/// Once specified as either inclusive or exclusive, it cannot be changed.
/// </summary>
internal enum TaxBehaviour
{
    Exclusive,
    Inclusive,
    Unspecified
}