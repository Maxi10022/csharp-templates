using FluentValidation;

namespace Template.Api.Branding.Options;

public sealed class BrandingOptionsValidator : AbstractValidator<BrandingOptions>
{
    public BrandingOptionsValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty();
        
        RuleFor(x => x.PrimaryColor)
            .NotEmpty();
    }
}