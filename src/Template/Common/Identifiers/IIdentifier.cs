using System.Diagnostics.CodeAnalysis;

namespace Common.Identifiers;

public interface IIdentifier<TSelf, TValue> where TSelf : IIdentifier<TSelf, TValue>
{
    /// <summary>
    /// The wrapped value.
    /// </summary>
    public TValue Value { get; }
    
    /// <summary>
    /// Creates the identifier wrap from the provided value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The identifier.</returns>
    public static abstract TSelf From(TValue value);

    /// <summary>
    /// Creates a new identifier.
    /// </summary>
    /// <returns>The identifier.</returns>
    public static abstract TSelf Create();
    
    /// <summary>
    /// Parse an identifier from a nullable string, might throw an exception!
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <returns>The identifier.</returns>
    public static abstract TSelf Parse(string? value);
    
    /// <summary>
    /// Tries to parse an identifier from a nullable string, will NOT throw an exception!
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <param name="result">The identifier, null if parsing failed.</param>
    /// <returns>True on parsing success, else false.</returns>
    public static abstract bool TryParse(string? value, [NotNullWhen(returnValue: true)] out TSelf? result);
}