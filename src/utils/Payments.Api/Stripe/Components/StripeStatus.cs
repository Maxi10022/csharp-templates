namespace Payments.Api.Stripe.Components;

/// <summary>
/// The objects' status within Stripes' systems.
/// Either Active or Inactive.
/// </summary>
internal enum StripeStatus
{
    /// <summary>
    /// The object is active and can be used.
    /// </summary>
    Active,
    /// <summary>
    /// The object is inactive. No more events for this object will be accepted.
    /// </summary>
    Inactive,
}