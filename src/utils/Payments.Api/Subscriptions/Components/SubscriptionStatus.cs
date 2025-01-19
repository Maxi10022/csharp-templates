namespace Payments.Api.Subscriptions.Components;

/// <summary>
/// The current subscription status.
/// <see href="https://docs.stripe.com/api/subscriptions/object?lang=dotnet#subscription_object-status">Learn more.</see>
/// </summary>
internal enum SubscriptionStatus
{
    Incomplete,
    IncompleteExpired,
    Trialing,
    Active,
    PastDue,
    Canceled,
    Unpaid,
    Paused
}