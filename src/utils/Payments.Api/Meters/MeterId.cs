using Common.Identifiers;

namespace Payments.Api.Meters;

public readonly record struct MeterId : IIdentifier<MeterId, Guid>
{
    public Guid Value { get; }
    
    private MeterId(Guid value) => Value = value;
    
    public static MeterId From(Guid value) => new(value);

    public static MeterId Create() => new(Ulid.NewUlid().ToGuid());
    public static MeterId Parse(string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        
        var id = Guid.Parse(value);

        return new MeterId(id);
    }

    public static bool TryParse(string? value, out MeterId result)
    {
        if (Guid.TryParse(value, out Guid id))
        {
            result = new MeterId(id);
            return true;
        }
        
        result = default;
        return false;
    }
}