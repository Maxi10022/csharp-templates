namespace Template.Api.Branding.Options;

public sealed class BrandingOptions
{
    public string CompanyName { get; init; } = null!;
    public string PrimaryColor { get; init; } = null!;
    public string? LogoUrl { get; init; }
}