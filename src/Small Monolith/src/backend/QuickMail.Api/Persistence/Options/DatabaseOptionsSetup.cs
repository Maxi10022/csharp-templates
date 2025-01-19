using Microsoft.Extensions.Options;

namespace QuickMail.Api.Persistence.Options;

internal sealed class DatabaseOptionsSetup(
    IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
{
    public const string SectionName = "ConnectionStrings";
    public void Configure(DatabaseOptions options)
    {
        configuration.GetRequiredSection(SectionName)
            .Bind(options);
    }
}