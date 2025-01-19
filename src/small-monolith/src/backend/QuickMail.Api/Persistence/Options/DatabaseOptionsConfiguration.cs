namespace QuickMail.Api.Persistence.Options;

internal static class DatabaseOptionsConfiguration
{
    public static IServiceCollection AddDatabaseOptions(
        this IServiceCollection services) =>
        services.ConfigureOptions<DatabaseOptionsSetup>();
}