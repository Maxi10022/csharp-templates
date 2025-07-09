using Microsoft.Extensions.Options;
using Template.Api.Branding.Options;

namespace Template.Api.Branding;

public class BrandingProvider(IOptionsSnapshot<BrandingOptions> optionsSnapshot)
{
    private readonly BrandingOptions _options =  optionsSnapshot.Value;
    
    public string CompanyName => _options.CompanyName;

    public string Copyright => $"© {DateTime.Now.Year} {CompanyName}";
    
    public string PrimaryColor => _options.PrimaryColor;
    
    public string? LogoUrl => _options.LogoUrl;
}