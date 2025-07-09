using FluentValidation;

namespace Template.Api.Users.Passwords;

public class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .MinimumLength(6)
            .Matches(@"[A-Za-z0-9]").WithMessage("Password must contain at least one alphanumeric character.")
            .Matches(@"\d").WithMessage("Password must contain at least one digit.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.");
    }
}