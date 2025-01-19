namespace QuickMail.Api.Authentication.Options;

internal sealed class AuthOptions
{
    public string JwtSecret { get; init; } = null!;

    public static AuthOptions FromConfiguration(IConfiguration configuration)
    {
        var options = new AuthOptions();
        
        var setup = new AuthOptionsSetup(configuration);
        
        setup.Configure(options);
        
        return options;
    }
}