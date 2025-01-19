using Payments.Api.Customers;
using Payments.Api.Prices;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;
using Payments.Api.SubscriptionItems;
using Payments.Api.Subscriptions.Components;

namespace Payments.Api.Subscriptions;

internal class Subscription : IStripeEntity
{
    /// <summary>
    /// The internal identifier for this subscription.
    /// </summary>
    public SubscriptionId Id { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="Stripe.StripeId"/>
    /// </summary>
    public StripeId StripeId { get; init; }
    
    /// <summary>
    /// The internal id of the customer who owns this subscription. 
    /// </summary>
    public CustomerId CustomerId { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="SubscriptionStatus"/>
    /// </summary>
    public SubscriptionStatus Status { get; set; }
    
    /// <summary>
    /// <inheritdoc cref="SupportedCurrency"/>
    /// </summary>
    public SupportedCurrency Currency { get; init; }
    
    /// <summary>
    /// End of the current period that the subscription has been invoiced for.
    /// At the end of this period, a new invoice will be created.
    /// </summary>
    public DateTime CurrentPeriodEnd { get; set; }
    
    /// <summary>
    /// Start of the current period that the subscription has been invoiced for.
    /// </summary>
    public DateTime CurrentPeriodStart { get; set; }
    
    /// <summary>
    /// A date in the future at which the subscription will automatically get canceled
    /// </summary>
    public DateTime? CancelAt { get; set; }
    
    /// <summary>
    /// This is an EF-Core navigation property.
    /// List of subscription items, each with an attached price.
    /// </summary>
    public IEnumerable<SubscriptionItem> SubscriptionItems { get; init; }
}