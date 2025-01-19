namespace Payments.Api.Prices.Components;

/// <summary>
/// Describes how to compute the price per period.
/// Either <c>PerUnit</c> or <c>Tiered</c>.
/// Read more
/// <see href="https://docs.stripe.com/api/prices/object?api-version=2024-12-18.acacia#price_object-billing_scheme">here.</see> 
/// </summary>
internal enum BillingScheme
{
    PerUnit,
    Tiered
}