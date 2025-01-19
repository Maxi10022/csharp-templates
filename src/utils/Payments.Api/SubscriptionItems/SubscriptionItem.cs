using Payments.Api.Prices;
using Payments.Api.Stripe;
using Payments.Api.Subscriptions;

namespace Payments.Api.SubscriptionItems;

internal class SubscriptionItem : IStripeEntity
{
    /// <summary>
    /// The internal unique identifier.
    /// </summary>
    public SubscriptionItemId Id { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="Stripe.StripeId"/>
    /// </summary>
    public StripeId StripeId { get; init; }
    
    /// <summary>
    /// The id of the <see cref="Subscription"/> this <see cref="SubscriptionItem"/> belongs to.
    /// </summary>
    public SubscriptionId SubscriptionId { get; init; }
    
    /// <summary>
    /// Time at which the object was created. Measured in seconds since the Unix epoch.
    /// </summary>
    public DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// The quantity of the plan to which the customer should be subscribed.
    /// </summary>
    public uint? Quantity { get; set; }
    
    /// <summary>
    /// The id of the price the customer is subscribed to.
    /// </summary>
    public PriceId PriceId { get; set; }
    
    /// <summary>
    /// An EF-Core navigation property.
    /// The recurring price for this subscription-item.
    /// </summary>
    public RecurringPrice Price { get; init; }
    
    /// <summary>
    /// An EF-Core navigation property.
    /// The Subscription this item belongs to. 
    /// </summary>
    public Subscription Subscription { get; init; }
}