using FluentValidation;

namespace Template.Api.Frontend.Options;

public sealed class FrontendOptionsValidator : AbstractValidator<FrontendOptions>
{
    public FrontendOptionsValidator()
    {
        RuleFor(options => options.Root)
            .NotEmpty()
            .Must(root => !root.EndsWith('/'))
            .WithMessage("Root must not end with /");
        
        RuleFor(options =>  options.Paths)
            .NotNull()
            .ChildRules(rules =>
            {
                rules.RuleFor(options => options.EmailConfirmed).NotEmpty();
                rules.RuleFor(options => options.OAuthRedirect).NotEmpty();
            });
    }
}