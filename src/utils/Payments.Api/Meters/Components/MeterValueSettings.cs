namespace Payments.Api.Meters.Components;

/// <summary>
/// Fields that specify how to calculate a meter event’s value.
/// </summary>
internal sealed record MeterValueSettings
{
    /// <summary>
    /// The key in the meter event payload to use as the value for this meter.
    /// </summary>
    public required string EventPayloadKey { get; init; }
}