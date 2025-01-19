using Common.Identifiers;

namespace Payments.Api.SubscriptionItems;

public readonly record struct SubscriptionItemId : IIdentifier<SubscriptionItemId, Guid>
{
    public Guid Value { get; }
    
    private SubscriptionItemId(Guid value) => Value = value;
    
    public static SubscriptionItemId From(Guid value) => new(value);

    public static SubscriptionItemId Create() => new(Ulid.NewUlid().ToGuid());
    public static SubscriptionItemId Parse(string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        
        var id = Guid.Parse(value);

        return new SubscriptionItemId(id);
    }

    public static bool TryParse(string? value, out SubscriptionItemId result)
    {
        if (Guid.TryParse(value, out Guid id))
        {
            result = new SubscriptionItemId(id);
            return true;
        }
        
        result = default;
        return false;
    }
}