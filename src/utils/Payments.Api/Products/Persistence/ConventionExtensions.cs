using Common.Identifiers.Persistence;
using Common.ValueTypes.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Payments.Api.Products.Components;

namespace Payments.Api.Products.Persistence;

public static class ConventionExtensions 
{
    public static ModelConfigurationBuilder ConfigureProductConventions(
        this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<ProductId>()
            .HaveConversion<GuidIdentityValueConverter<ProductId>>();

        configurationBuilder.Properties<ProductName>()
            .HaveConversion<StringValueConverter<ProductName>>();

        configurationBuilder.Properties<ProductDescription>()
            .HaveConversion<StringValueConverter<ProductDescription>>();
        
        return configurationBuilder;
    }

    public static NpgsqlDbContextOptionsBuilder MapProductEnums(
        this NpgsqlDbContextOptionsBuilder options, 
        string schema) => options;
}