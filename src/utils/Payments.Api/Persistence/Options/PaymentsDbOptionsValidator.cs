using FluentValidation;

namespace Payments.Api.Persistence.Options;

internal sealed class PaymentsDbOptionsValidator : AbstractValidator<PaymentsDbOptions>
{
    public PaymentsDbOptionsValidator()
    {
        RuleFor(options => options.ConnectionString)
            .NotNull()
            .WithMessage("Connection string was null.")
            .NotEmpty()
            .WithMessage("Connection string was empty.");
    }
}