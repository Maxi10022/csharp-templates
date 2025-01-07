using Common.ValueTypes;

namespace Payments.Api.Products.Components;

/// <summary>
/// The product’s name, meant to be displayable to the customer.
/// </summary>
internal sealed class ProductName : IValueType<ProductName, string>
{
    private ProductName(string name) => Value = name;
    
    public string Value { get; }
    
    public static ProductName Create(string value) => new(value);
}