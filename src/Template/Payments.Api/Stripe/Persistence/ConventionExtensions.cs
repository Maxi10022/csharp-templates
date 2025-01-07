using Common.Identifiers.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Payments.Api.Persistence;
using Payments.Api.Persistence.Options;
using Payments.Api.Stripe.Components;

namespace Payments.Api.Stripe.Persistence;

public static class ConventionExtensions
{
    public static ModelConfigurationBuilder ConfigureCommonStripeConventions(
        this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<StripeId>()
            .HaveConversion<StringIdentityValueConverter<StripeId>>();
        
        return configurationBuilder;
    }
    
    public static NpgsqlDbContextOptionsBuilder MapCommonStripeEnums(
        this NpgsqlDbContextOptionsBuilder options, string schema) => options
        .MapEnum<StripeMode>(schemaName: schema)
        .MapEnum<SupportedCurrency>(schemaName: schema)
        .MapEnum<StripeStatus>(schemaName: schema);
}