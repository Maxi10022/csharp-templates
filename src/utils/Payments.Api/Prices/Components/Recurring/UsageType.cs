namespace Payments.Api.Prices.Components.Recurring;

/// <summary>
/// Configures how the quantity per period should be determined.
/// Can be either <c>Metered</c> or <c>Licensed</c>.
/// <c>Licensed</c> automatically bills the quantity set when adding it to a subscription.
/// <c>Metered</c> aggregates the total usage based on usage records.
/// Defaults to <c>Licensed</c>.
/// </summary>
internal enum UsageType
{
    Metered,
    Licensed
}