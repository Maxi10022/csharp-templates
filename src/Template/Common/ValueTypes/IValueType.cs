namespace Common.ValueTypes;

/// <summary>
/// Generic interface for value types wrapping some other value. 
/// </summary>
/// <typeparam name="TSelf">The value type.</typeparam>
/// <typeparam name="TValue">The wrapped type.</typeparam>
public interface IValueType<out TSelf, TValue> where TSelf : IValueType<TSelf, TValue>
{
    /// <summary>
    /// The wrapped value.
    /// </summary>
    public TValue Value { get; }
    
    /// <summary>
    /// Allows creation of the value type using its value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The value type.</returns>
    public static abstract TSelf Create(TValue value);  
}