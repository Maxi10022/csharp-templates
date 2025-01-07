using Payments.Api.Meters;
using Payments.Api.Prices.Components.Recurring;

namespace Payments.Api.Prices;

/// <summary>
/// Represents a recurring price. 
/// </summary>
internal class RecurringPrice : PriceBase
{
    /// <summary>
    /// <inheritdoc cref="Components.Recurring.AggregateUsage"/>
    /// </summary>
    public AggregateUsage? AggregateUsage { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="TimeInterval"/>
    /// </summary>
    public TimeInterval Interval { get; init; }
    
    /// <summary>
    /// The number of intervals (specified in the interval attribute) between subscription billings.
    /// For example, <see cref="Interval"/>=<c>Month</c> and <see cref="IntervalCount"/>=<c>3</c> bills every 3 months.
    /// </summary>
    public uint IntervalCount { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="Components.Recurring.UsageType"/>
    /// </summary>
    public UsageType UsageType { get; init; }
    
    /// <summary>
    /// The meter tracking the usage of a metered price.
    /// </summary>
    public MeterId? MeterId { get; init; }
}