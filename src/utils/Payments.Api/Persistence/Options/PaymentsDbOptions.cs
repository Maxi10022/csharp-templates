using Payments.Api.Stripe;

namespace Payments.Api.Persistence.Options;

internal sealed class PaymentsDbOptions
{ 
    [ConfigurationKeyName("Payments")] 
    public string ConnectionString { get; set; }
}