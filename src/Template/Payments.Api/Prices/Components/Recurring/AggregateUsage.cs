namespace Payments.Api.Prices.Components.Recurring;

/// <summary>
/// Specifies a usage aggregation strategy for prices of <c>usage_type=metered</c>. Defaults to <c>sum</c>.
/// Read more
/// <see href="https://docs.stripe.com/api/prices/object?api-version=2024-12-18.acacia#price_object-recurring">here.</see>.
/// </summary>
internal enum AggregateUsage
{
    /// <summary>
    /// Use the last usage record reported within a period.
    /// </summary>
    LastDuringPeriod,
    /// <summary>
    /// Use the last usage record ever reported (across period bounds).
    /// </summary>
    LastEver,
    /// <summary>
    /// Use the usage record with the maximum reported usage during a period.
    /// </summary>
    Max,
    /// <summary>
    /// Sum up all usage during a period. This is the default behavior.
    /// </summary>
    Sum
}