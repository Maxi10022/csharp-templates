using System.Diagnostics.CodeAnalysis;
using Common.Identifiers;

namespace Payments.Api.Stripe;

/// <summary>
/// Unique identifier of an object within Stripes' system. 
/// </summary>
public sealed record StripeId : IIdentifier<StripeId, string>
{
    public string Value { get; }
    
    private StripeId(string value) => Value = value;
    
    public static StripeId From(string value) => new(value);
    public static StripeId Create()
    {
        throw new NotSupportedException("Only stripe can create new StripeId objects.");
    }

    public static StripeId Parse(string? value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        
        return new StripeId(value);
    }

    public static bool TryParse(string? value, [NotNullWhen(true)] out StripeId? result)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            result = null;
            return false;
        }
        
        result = new StripeId(value);
        return true;
    }
}