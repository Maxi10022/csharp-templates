using Microsoft.Extensions.Options;

namespace QuickMail.Api.Authentication.Options;

internal sealed class AuthOptionsSetup(
    IConfiguration configuration) : IConfigureOptions<AuthOptions>
{
    public const string SectionName = "Auth";
    
    public void Configure(AuthOptions options)
    {
        configuration.GetRequiredSection(SectionName)
            .Bind(options);
    }
}