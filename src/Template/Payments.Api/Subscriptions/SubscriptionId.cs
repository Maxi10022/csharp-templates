using Common.Identifiers;

namespace Payments.Api.Subscriptions;

public readonly record struct SubscriptionId : IIdentifier<SubscriptionId, Guid>
{
    public Guid Value { get; }
    
    private SubscriptionId(Guid value) => Value = value;
    
    public static SubscriptionId From(Guid value) => new(value);

    public static SubscriptionId Create() => new(Ulid.NewUlid().ToGuid());
    public static SubscriptionId Parse(string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        
        var id = Guid.Parse(value);

        return new SubscriptionId(id);
    }

    public static bool TryParse(string? value, out SubscriptionId result)
    {
        if (Guid.TryParse(value, out Guid id))
        {
            result = new SubscriptionId(id);
            return true;
        }
        
        result = default;
        return false;
    }
}