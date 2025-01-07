namespace Payments.Api.Meters.Components;

/// <summary>
/// The timestamps at which the meter status changed.
/// </summary>
internal sealed record MeterStatusTransitions
{
    /// <summary>
    /// The time the meter was deactivated, if any. Measured in seconds since Unix epoch.
    /// </summary>
    public DateTime? DeactivatedAt { get; set; }
}