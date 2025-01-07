using Common.Identifiers;

namespace Payments.Api.Customers;

public readonly record struct CustomerId : IIdentifier<CustomerId, Guid>
{
    public Guid Value { get; }
    
    private CustomerId(Guid value) => Value = value;
    
    public static CustomerId From(Guid value) => new(value);

    public static CustomerId Create() => new(Ulid.NewUlid().ToGuid());
    public static CustomerId Parse(string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        
        var id = Guid.Parse(value);

        return new CustomerId(id);
    }

    public static bool TryParse(string? value, out CustomerId result)
    {
        if (Guid.TryParse(value, out Guid id))
        {
            result = new CustomerId(id);
            return true;
        }
        
        result = default;
        return false;
    }
}