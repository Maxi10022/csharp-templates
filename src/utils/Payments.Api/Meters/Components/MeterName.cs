using Common.ValueTypes;

namespace Payments.Api.Meters.Components;

/// <summary>
/// The meter’s name.
/// </summary>
internal sealed record MeterName : IValueType<MeterName, string>
{
    private MeterName(string name) => Value = name;
    
    /// <summary>
    /// <inheritdoc cref="MeterName"/>
    /// </summary>
    public string Value { get; }

    public static MeterName Create(string value) => new(value);
}