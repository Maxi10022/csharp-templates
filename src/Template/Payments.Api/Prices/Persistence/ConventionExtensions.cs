using Common.Identifiers.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Payments.Api.Prices.Components;
using Payments.Api.Prices.Components.Recurring;
using Payments.Api.Stripe;

namespace Payments.Api.Prices.Persistence;

public static class ConventionExtensions 
{
    public static ModelConfigurationBuilder ConfigurePriceConventions(
        this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<PriceId>()
            .HaveConversion<GuidIdentityValueConverter<PriceId>>();
        
        return configurationBuilder;
    }

    public static NpgsqlDbContextOptionsBuilder MapPriceEnums(
        this NpgsqlDbContextOptionsBuilder options,
        string schema) => options
        .MapEnum<AggregateUsage>(schemaName: schema)
        .MapEnum<TimeInterval>(schemaName: schema)
        .MapEnum<UsageType>(schemaName: schema)
        .MapEnum<BillingScheme>(schemaName: schema)
        .MapEnum<TaxBehaviour>(schemaName: schema);
}