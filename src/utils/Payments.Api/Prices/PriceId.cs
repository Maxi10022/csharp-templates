using Common.Identifiers;

namespace Payments.Api.Prices;

public readonly record struct PriceId : IIdentifier<PriceId, Guid>
{
    public Guid Value { get; }
    
    private PriceId(Guid value) => Value = value;
    
    public static PriceId From(Guid value) => new(value);

    public static PriceId Create() => new(Ulid.NewUlid().ToGuid());
    public static PriceId Parse(string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        
        var id = Guid.Parse(value);

        return new PriceId(id);
    }

    public static bool TryParse(string? value, out PriceId result)
    {
        if (Guid.TryParse(value, out Guid id))
        {
            result = new PriceId(id);
            return true;
        }
        
        result = default;
        return false;
    }
}