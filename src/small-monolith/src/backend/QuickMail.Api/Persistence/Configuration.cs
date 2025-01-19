using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuickMail.Api.Persistence.Options;

namespace QuickMail.Api.Persistence;

internal static class Configuration
{
    public static IServiceCollection AddAppDbContext(
        this IServiceCollection services) => services
        .AddDatabaseOptions()
        .AddDbContext<AppDbContext>((serviceProvider, builder) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

            builder.UseNpgsql(options.ConnectionString)
                .UseSnakeCaseNamingConvention();
        });
}