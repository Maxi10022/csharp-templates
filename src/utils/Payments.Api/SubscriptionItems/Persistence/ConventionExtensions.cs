using Common.Identifiers.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Payments.Api.Stripe;

namespace Payments.Api.SubscriptionItems.Persistence;

public static class ConventionExtensions
{
    public static ModelConfigurationBuilder ConfigureSubscriptionItemConventions(
        this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<SubscriptionItemId>()
            .HaveConversion<GuidIdentityValueConverter<SubscriptionItemId>>();
        
        return configurationBuilder;
    }
    
    public static NpgsqlDbContextOptionsBuilder MapSubscriptionItemEnums(
        this NpgsqlDbContextOptionsBuilder options, 
        string schema) => options;
}