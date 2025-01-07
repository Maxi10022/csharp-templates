using Payments.Api.Prices.Components;
using Payments.Api.Products;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;

namespace Payments.Api.Prices;

internal abstract class PriceBase : IStripeEntity
{
    /// <summary>
    /// The internal price id.
    /// </summary>
    public PriceId Id { get; init; }
    
    /// <summary>
    /// The price id within Stripes system
    /// </summary>
    public StripeId StripeId { get; init; }
    
    /// <summary>
    /// The product this price is designed for. 
    /// </summary>
    public ProductId ProductId { get; init; }
    
    /// <summary>
    /// The product object, a navigation property populated by EF-Core.
    /// </summary>
    public Product Product { get; init; }
    
    /// <summary>
    /// Time at which the price was created. Measured in seconds since the Unix epoch.
    /// </summary>
    public DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="SupportedCurrency"/>
    /// </summary>
    public SupportedCurrency Currency { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="BillingScheme"/>
    /// </summary>
    public BillingScheme BillingScheme { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="Components.TaxBehaviour"/>
    /// </summary>
    public TaxBehaviour TaxBehaviour { get; set; }
    
    /// <summary>
    /// <inheritdoc cref="StripeMode"/>
    /// </summary>
    public StripeMode Mode { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="StripeStatus"/>
    /// </summary>
    public StripeStatus Status { get; set; }
    
    /// <summary>
    /// The unit amount in cents to be charged, represented as a whole integer if possible.
    /// Only set if <see cref="BillingScheme"/>=<c>PerUnit</c>.
    /// </summary>
    public uint? UnitAmount { get; init; } 
    
    /// <summary>
    /// Same as <see cref="UnitAmount"/>, but accepts a decimal value in cents with at most 12 decimal places.
    /// Only one of <see cref="UnitAmount"/> and <see cref="UnitAmountDecimal"/> can be set.
    /// </summary>
    public decimal? UnitAmountDecimal { get; init; } 
}