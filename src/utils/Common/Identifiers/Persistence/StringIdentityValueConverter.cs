using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.Identifiers.Persistence;

public class StringIdentityValueConverter<T> : ValueConverter<T, string> where T : IIdentifier<T, string>
{
    public StringIdentityValueConverter() : base(
        convertToProviderExpression: id => id.Value, 
        convertFromProviderExpression: value => ConvertFromString(value)) { }
    
    private static T ConvertFromString(string value) => T.From(value);
}