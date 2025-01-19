namespace Payments.Api.Meters.Components;

/// <summary>
/// The time window to pre-aggregate meter events for, if any.
/// </summary>
internal enum MeterEventTimeWindow
{
    /// <summary>
    /// Events are pre-aggregated in daily buckets.
    /// </summary>
    Day,
    /// <summary>
    /// Events are pre-aggregated in hourly buckets.
    /// </summary>
    Hour
}