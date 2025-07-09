using Template.Api.Common.Options;
using Template.Api.Branding.Options;

namespace Template.Api.Branding;

public static class BrandingConfiguration
{
    public static IServiceCollection AddBrandingServices(this IServiceCollection services) => services
            .AddOptionsWithFluentValidation<BrandingOptions>("Branding")
            .AddScoped<BrandingProvider>();
}