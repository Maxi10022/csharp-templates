using FluentValidation;

namespace Payments.Api.Stripe.Options;

internal static class StripeOptionsConfiguration
{
    public static IServiceCollection AddStripeOptions(
        this IServiceCollection services) => 
        services
            .ConfigureOptions<StripeOptionsSetup>()
            .AddSingleton<IValidator<StripeOptions>, StripeOptionsValidator>();
}