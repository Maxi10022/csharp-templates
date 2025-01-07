using Common.Emails;
using Payments.Api.Stripe;

namespace Payments.Api.Customers;

/// <summary>
/// Represents a customer. 
/// </summary>
internal class Customer : IStripeEntity
{
    /// <summary>
    /// The internal customer id. 
    /// </summary>
    public CustomerId Id { get; init; }
    
    /// <summary>
    /// The customers identifier within Stripes system.
    /// Will always stay the same, can be relied on. 
    /// </summary>
    public StripeId StripeId { get; init; }
    
    /// <summary>
    /// The customers email, provided by Stripe.
    /// Might be changed by stripe, do not rely on it.
    /// </summary>
    public Email Email { get; init; }
    
    /// <summary>
    /// Optional. The customers name.
    /// </summary>
    public string? Name { get; init; }
    
    /// <summary>
    /// Time since the customer was created in Stripes systems.
    /// Measured in seconds elapsed since Unix epoch. 
    /// </summary>
    public DateTime CreatedAt { get; init; }
    
    public static Customer NewFromStripe(global::Stripe.Customer customer) =>
        new()
        {
            Id = CustomerId.Create(),
            StripeId = StripeId.From(customer.Id),
            Email = Email.Create(customer.Email),
            Name = customer.Name,
            CreatedAt = customer.Created
        };
}