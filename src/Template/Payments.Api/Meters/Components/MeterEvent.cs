namespace Payments.Api.Meters.Components;

/// <summary>
/// The name and optional time window of the event for this meter, used to collect usage for. 
/// </summary>
internal sealed record MeterEvent
{
    /// <summary>
    /// The name of the meter event to record usage for. 
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// <inheritdoc cref="MeterEventTimeWindow"/>
    /// </summary>
    public MeterEventTimeWindow? TimeWindow { get; init; }
}