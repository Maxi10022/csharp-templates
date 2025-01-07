using FluentValidation;
using Microsoft.Extensions.Options;

namespace Payments.Api.Stripe.Options;

internal sealed class StripeOptionsSetup(
    IConfiguration configuration,
    IValidator<StripeOptions> validator) : IConfigureOptions<StripeOptions>
{
    private const string SectionName = "Stripe";

    public void Configure(StripeOptions options)
    {
        configuration
            .GetRequiredSection(SectionName)
            .Bind(options);
        
        validator.ValidateAndThrow(options);
    }
}