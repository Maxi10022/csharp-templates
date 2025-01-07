using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.ValueTypes.Persistence;

public class StringValueConverter<T> : ValueConverter<T, string> where T : IValueType<T, string>
{
    public StringValueConverter() : base(
        convertToProviderExpression: id => id.Value, 
        convertFromProviderExpression: value => ConvertFromString(value)) { }
    
    private static T ConvertFromString(string value) => T.Create(value);
}