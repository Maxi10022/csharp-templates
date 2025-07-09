namespace Template.Api.Common.Options;

public static class OptionsConfiguration
{
    public static IServiceCollection AddOptionsWithFluentValidation<TOptions>(
        this IServiceCollection services,
        string sectionName
    ) where TOptions : class
    {
        services.AddOptions<TOptions>()
            .BindConfiguration(sectionName)
            .ValidateFluentValidation()
            .ValidateOnStart();
        
        return services;
    }
}