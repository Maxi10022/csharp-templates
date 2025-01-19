namespace Payments.Api.Meters.Components;

/// <summary>
/// Timestamps container for the Meter object.
/// </summary>
internal sealed record MeterTimestamps
{
    /// <summary>
    /// Time at which the object was created. Measured in seconds since the Unix epoch.
    /// </summary>
    public required DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// Time at which the object was last updated. Measured in seconds since the Unix epoch.
    /// </summary>
    public required DateTime UpdatedAt { get; set; }
}