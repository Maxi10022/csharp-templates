using FluentValidation;

namespace Payments.Api.Persistence.Options;

internal static class PaymentsDbOptionsConfiguration
{
    public static IServiceCollection AddPaymentsDbOptions(this IServiceCollection services) =>
        services
            .ConfigureOptions<PaymentsDbOptionsSetup>()
            .AddSingleton<IValidator<PaymentsDbOptions>, PaymentsDbOptionsValidator>();
}