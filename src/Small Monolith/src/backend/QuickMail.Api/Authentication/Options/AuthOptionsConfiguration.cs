namespace QuickMail.Api.Authentication.Options;

internal static class AuthOptionsConfiguration
{
    public static IServiceCollection ConfigureAuthOptions(
        this IServiceCollection services) =>
        services.ConfigureOptions<AuthOptionsSetup>();
}