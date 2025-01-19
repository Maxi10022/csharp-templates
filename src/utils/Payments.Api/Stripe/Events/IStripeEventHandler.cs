using Stripe;

namespace Payments.Api.Stripe.Events;

/// <summary>
/// Interface for a Stripe event handler
/// </summary>
internal interface IStripeEventHandler
{
    /// <summary>
    /// Publish the event without handling it.
    /// Recommended for use in the webhook endpoint for fast webhook receives. 
    /// </summary>
    /// <param name="stripeEvent">The Stripe <see cref="Event"/></param>
    /// <returns>A task</returns>
    public Task Publish(Event stripeEvent);
    
    /// <summary>
    /// Handle the stripe event.
    /// The caller will need to await the complete process.
    /// </summary>
    /// <param name="stripeEvent">The Stripe <see cref="Event"/></param>
    /// <returns>A task</returns>
    public Task Handle(Event stripeEvent);
}