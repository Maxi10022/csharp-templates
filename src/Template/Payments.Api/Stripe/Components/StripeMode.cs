namespace Payments.Api.Stripe.Components;

/// <summary>
/// The object is either in live or test mode within Stripes' systems. 
/// </summary>
internal enum StripeMode
{
    /// <summary>
    /// The object is in live mode.
    /// </summary>
    Live,
    /// <summary>
    /// The object is in test mode.
    /// </summary>
    Test
}