using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Payments.Api.Meters.Persistence;
using Payments.Api.Persistence.Options;
using Payments.Api.Prices.Persistence;
using Payments.Api.Products.Persistence;
using Payments.Api.Stripe.Persistence;
using Payments.Api.SubscriptionItems.Persistence;
using Payments.Api.Subscriptions.Persistence;

namespace Payments.Api.Persistence;

public static class PaymentsDbContextConfiguration
{
    public static IServiceCollection AddPaymentsDbContext(this IServiceCollection services)
    {
        services.AddPaymentsDbOptions();
        
        services.AddDbContext<PaymentsDbContext>((serviceProvider, options) =>
        {
            var paymentsDbOptions = serviceProvider.GetRequiredService<IOptions<PaymentsDbOptions>>();
            
            var connectionString = paymentsDbOptions.Value.ConnectionString;

            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions
                    .MapCommonStripeEnums(PaymentsDbContext.Schema)
                    .MapMeterEnums(PaymentsDbContext.Schema)
                    .MapPriceEnums(PaymentsDbContext.Schema)
                    .MapProductEnums(PaymentsDbContext.Schema)
                    .MapSubscriptionItemEnums(PaymentsDbContext.Schema)
                    .MapSubscriptionEnums(PaymentsDbContext.Schema);
            });
        });
        
        return services;
    }
}