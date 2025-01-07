using FluentValidation;

namespace Payments.Api.Stripe.Options;

internal sealed class StripeOptionsValidator : AbstractValidator<StripeOptions>
{
    public StripeOptionsValidator()
    {
        RuleFor(options => options.ApiKey)
            .NotNull()
            .WithMessage("Stripe API key cannot be null!")
            .NotEmpty()
            .WithMessage("Stripe API key cannot be empty!");
        
        RuleFor(options => options.WebhookSecret)
            .NotNull()
            .WithMessage("Stripe API key cannot be null!")
            .NotEmpty()
            .WithMessage("Stripe API key cannot be empty!");
    }
}