using Payments.Api.Prices;
using Payments.Api.Products.Components;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;

namespace Payments.Api.Products;

internal class Product : IStripeEntity
{
    /// <summary>
    /// The products internal unique identifier.
    /// </summary>
    public required ProductId Id { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="Stripe.StripeId"/>
    /// </summary>
    public required StripeId StripeId { get; init; }
    
    /// <summary>
    /// Time at which the object was created. Measured in seconds since the Unix epoch.
    /// </summary>
    public required DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// Time at which the object was last updated. Measured in seconds since the Unix epoch.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    /// <inheritdoc cref="ProductDescription"/>
    /// </summary>
    public ProductDescription? Description { get; set; }
    
    /// <summary>
    /// <inheritdoc cref="ProductName"/>
    /// </summary>
    public required ProductName Name { get; set; }
    
    /// <summary>
    /// <inheritdoc cref="StripeMode"/>
    /// </summary>
    public required StripeMode Mode { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="StripeStatus"/>
    /// </summary>
    public required StripeStatus Status { get; set; }
    
    /// <summary>
    /// The ID of the Price object that is the default price for this product.
    /// </summary>
    public PriceId? DefaultPriceId { get; set; }
    
    /// <summary>
    /// The default price, a navigation property populated by EF-Core. 
    /// </summary>
    public PriceBase? DefaultPrice { get; init; }
}