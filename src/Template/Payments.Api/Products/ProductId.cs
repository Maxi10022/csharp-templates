using Common.Identifiers;

namespace Payments.Api.Products;

public readonly record struct ProductId : IIdentifier<ProductId, Guid>
{
    public Guid Value { get; }
    
    private ProductId(Guid value) => Value = value;
    
    public static ProductId From(Guid value) => new(value);

    public static ProductId Create() => new(Ulid.NewUlid().ToGuid());
    public static ProductId Parse(string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        
        var id = Guid.Parse(value);

        return new ProductId(id);
    }

    public static bool TryParse(string? value, out ProductId result)
    {
        if (Guid.TryParse(value, out Guid id))
        {
            result = new ProductId(id);
            return true;
        }
        
        result = default;
        return false;
    }
}