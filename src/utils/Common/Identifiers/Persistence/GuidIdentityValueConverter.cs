using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.Identifiers.Persistence;

public class GuidIdentityValueConverter<T> : ValueConverter<T, Guid> where T : IIdentifier<T, Guid>
{
    public GuidIdentityValueConverter() : base(
        convertToProviderExpression: id => id.Value, 
        convertFromProviderExpression: value => ConvertFromGuid(value)) { }
    
    private static T ConvertFromGuid(Guid value) => T.From(value);
}