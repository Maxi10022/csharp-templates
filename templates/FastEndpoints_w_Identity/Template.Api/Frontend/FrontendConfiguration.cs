using Template.Api.Common.Options;
using Template.Api.Frontend.Options;

namespace Template.Api.Frontend;

public static class FrontendConfiguration
{
    public static IServiceCollection AddFrontendServices(this IServiceCollection services)
    {
        services.AddOptionsWithFluentValidation<FrontendOptions>("Frontend");
        services.AddScoped<FrontendRouteProvider>();
        return services;
    }
}