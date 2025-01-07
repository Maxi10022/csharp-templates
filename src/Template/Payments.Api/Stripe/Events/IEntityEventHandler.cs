using Stripe;

namespace Payments.Api.Stripe.Events;

internal interface IEntityEventHandler<TEntity> where TEntity : IStripeEntity
{
    public Task Handle(Event stripeEvent, CancellationToken ct = default);
    // TODO Implement entity specific event handlers
}