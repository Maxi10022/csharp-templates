using Common.Identifiers.Persistence;
using Common.ValueTypes.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Payments.Api.Meters.Components;

namespace Payments.Api.Meters.Persistence;

public static class ConventionExtensions 
{
    public static ModelConfigurationBuilder ConfigureMeterConventions(
        this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<MeterId>()
            .HaveConversion<GuidIdentityValueConverter<MeterId>>();

        configurationBuilder.Properties<MeterName>()
            .HaveConversion<StringValueConverter<MeterName>>();
        
        return configurationBuilder;
    }

    public static NpgsqlDbContextOptionsBuilder MapMeterEnums(
        this NpgsqlDbContextOptionsBuilder options,
        string schema) => options
        .MapEnum<MeterEventTimeWindow>(schemaName: schema);
}