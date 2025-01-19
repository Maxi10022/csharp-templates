using FastEndpoints.Security;
using QuickMail.Api.Authentication.Options;

namespace QuickMail.Api.Authentication;

internal static class Configuration
{
    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureAuthOptions();
        
        services.AddAuthenticationJwtBearer(jwtSigningOptions =>
        {
            var options = AuthOptions.FromConfiguration(configuration);

            jwtSigningOptions.SigningKey = options.JwtSecret;
        });
        
        return services;
    }
}