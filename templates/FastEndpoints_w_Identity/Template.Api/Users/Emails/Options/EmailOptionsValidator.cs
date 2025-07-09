using FluentValidation;

namespace Template.Api.Users.Emails.Options;

public sealed class EmailOptionsValidator : AbstractValidator<EmailOptions>
{
    public EmailOptionsValidator()
    {
        RuleFor(options => options.Server)
            .NotEmpty();
        
        RuleFor(options => options.Port)
            .NotNull()
            .NotEqual(0);

        RuleFor(options => options.Username)
            .NotEmpty();

        RuleFor(options => options.Password)
            .NotEmpty();

        RuleFor(options => options.EnableSsl)
            .NotNull();
    }
}