using FastEndpoints;
using Microsoft.Extensions.Options;
using Payments.Api.Stripe.Events;
using Payments.Api.Stripe.Options;
using Stripe;

namespace Payments.Api.Stripe;

internal static class Webhook
{
    public sealed class Request
    {
        [FromHeader("Stripe-Signature")] public string? Signature { get; init; }
        
        [FromBody] public string? Body { get; init; }
    }
    public sealed class Endpoint : Endpoint<Request>
    {
        private readonly StripeOptions _stripeOptions;
        private readonly IStripeEventHandler _stripeEventHandler;
        private readonly ILogger<Endpoint> _logger;

        public Endpoint(
            IOptionsSnapshot<StripeOptions> stripeOptionsSnapshot, 
            IStripeEventHandler stripeEventHandler, 
            ILogger<Endpoint> logger)
        {
            _stripeEventHandler = stripeEventHandler;
            _logger = logger;
            _stripeOptions = stripeOptionsSnapshot.Value;
        }

        public override void Configure()
        {
            Post("stripe/webhook");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json: req.Body, 
                    stripeSignatureHeader: req.Signature, 
                    secret: _stripeOptions.WebhookSecret);
                
                await _stripeEventHandler.Publish(stripeEvent);

                await SendOkAsync(ct);
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, ex.StripeError.Message);
                
                ThrowError(
                    property: request => request.Signature,
                    errorMessage: ex.StripeError.Message);
            }
        }
    }
}