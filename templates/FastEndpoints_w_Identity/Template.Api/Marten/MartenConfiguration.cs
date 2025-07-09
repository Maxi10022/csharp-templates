using JasperFx;
using JasperFx.Events.Daemon;
using Marten;
using Marten.Schema;
using Template.Api.Users;

namespace Template.Api.Marten;

public static class MartenConfiguration
{
    public static WebApplicationBuilder AddMarten(
        this WebApplicationBuilder builder
    )
    {
        builder.Services.AddMarten(options =>
            {
                options.ConfigureDatabaseConnection(builder)
                    .ConfigureSerializationAndLogging()
                    .ConfigureProjections()
                    .ConfigureSchemaDocuments();
            })
            .UseLightweightSessions()
            .AddAsyncDaemon(DaemonMode.HotCold);
        
        return builder;
    }

    private static StoreOptions ConfigureSchemaDocuments(this StoreOptions options)
    {
        options.Schema.For<User>()
            .UniqueIndex(UniqueIndexType.Computed, user => user.Email!);
        
        return options;
    }

    private static StoreOptions ConfigureProjections(this StoreOptions options)
    {
        options.Events.EnableSideEffectsOnInlineProjections = true;
        return options;
    }

    private static StoreOptions ConfigureSerializationAndLogging(this StoreOptions options)
    {
        options.UseSystemTextJsonForSerialization();
        options.DisableNpgsqlLogging = true;
        return options;
    }

    private static StoreOptions ConfigureDatabaseConnection(
        this StoreOptions options, 
        WebApplicationBuilder builder
    )
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
        options.Connection(connectionString);

        if (builder.Environment.IsDevelopment())
        {
            options.AutoCreateSchemaObjects = AutoCreate.All;
        }
        
        return options;
    }
}