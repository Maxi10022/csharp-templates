using Payments.Api.Stripe.Events;
using Stripe;

namespace Payments.Api.Prices;

internal sealed class PriceEventHandler : IEntityEventHandler<PriceBase>
{
    public Task Handle(Event stripeEvent, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}