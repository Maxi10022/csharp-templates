using Common.ValueTypes;

namespace Payments.Api.Products.Components;

/// <summary>
/// The product’s description, meant to be displayable to the customer.
/// Use this field to optionally store a long form explanation of the product being sold for your own rendering purposes.
/// </summary>
internal sealed class ProductDescription : IValueType<ProductDescription, string>
{
    private ProductDescription(string name) => Value = name;
    
    public string Value { get; }
    
    public static ProductDescription Create(string value) => new(value);
}