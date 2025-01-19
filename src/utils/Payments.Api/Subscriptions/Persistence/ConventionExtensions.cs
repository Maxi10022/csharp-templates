using Common.Identifiers.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Payments.Api.Subscriptions.Components;

namespace Payments.Api.Subscriptions.Persistence;

internal static class ConventionExtensions
{
    public static ModelConfigurationBuilder ConfigureSubscriptionConventions(
        this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<SubscriptionId>()
            .HaveConversion<GuidIdentityValueConverter<SubscriptionId>>();
        
        return configurationBuilder;
    }
    
    public static NpgsqlDbContextOptionsBuilder MapSubscriptionEnums(
        this NpgsqlDbContextOptionsBuilder options, string schema) => options
        .MapEnum<SubscriptionStatus>(schemaName: schema);
}