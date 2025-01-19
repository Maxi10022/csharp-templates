using Payments.Api.Customers;
using Payments.Api.Meters.Components;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;
using MeterEvent = Payments.Api.Meters.Components.MeterEvent;
using MeterStatusTransitions = Payments.Api.Meters.Components.MeterStatusTransitions;
using MeterValueSettings = Payments.Api.Meters.Components.MeterValueSettings;

namespace Payments.Api.Meters;

internal class Meter : IStripeEntity
{
    /// <summary>
    /// Internal id for the Meter object.
    /// </summary>
    public MeterId Id { get; init; }
    
    /// <summary>
    /// Unique identifier for this meter within Stripes' system.  
    /// </summary>
    public StripeId StripeId { get; init; } = null!;
    
    /// <summary>
    /// <inheritdoc cref="MeterTimestamps"/>
    /// </summary>
    public MeterTimestamps Timestamps { get; init; } = null!;
    
    /// <summary>
    /// The customer id to map this meter to a customer. 
    /// </summary>
    public CustomerId CustomerId { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="MeterName"/>
    /// </summary>
    public MeterName DisplayName { get; set; } = null!;
    
    /// <summary>
    /// <inheritdoc cref="Components.MeterEvent"/>
    /// </summary>
    public MeterEvent Event { get; init; } = null!;
    
    /// <summary>
    /// <inheritdoc cref="Components.MeterStatusTransitions"/>
    /// </summary>
    public MeterStatusTransitions StatusTransitions { get; init; } = null!;
    
    /// <summary>
    /// <inheritdoc cref="Components.MeterValueSettings"/>
    /// </summary>
    public MeterValueSettings ValueSettings { get; init; } = null!;
    
    /// <summary>
    /// <inheritdoc cref="StripeStatus"/>
    /// </summary>
    public StripeStatus Status { get; init; } 
    
    /// <summary>
    /// <inheritdoc cref="StripeMode"/>
    /// </summary>
    public StripeMode Mode { get; init; }
}
