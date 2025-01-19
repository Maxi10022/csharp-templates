using System.ComponentModel.DataAnnotations;
using Common.ValueTypes;

namespace Common.Emails;

/// <summary>
/// Defines a syntactically correct email.
/// </summary>
public sealed record Email : IValueType<Email, string>
{
    private static readonly EmailAddressAttribute _addressAttribute = new();
    
    private Email(string value) => Value = value;
    
    /// <summary>
    /// The email as string value.
    /// </summary>
    public string Value { get; }
    
    /// <summary>
    /// Creates an email, validates the strings correct format.
    /// </summary>
    /// <param name="value">The string.</param>
    /// <returns>The <see cref="Email"/></returns>
    /// <exception cref="InvalidDataException">Thrown if the strings format was not valid as an email</exception>
    public static Email Create(string value)
    {
        if (!string.IsNullOrWhiteSpace(value) && 
            _addressAttribute.IsValid(value))
        {
            return new Email(value);
        }

        throw new InvalidDataException("Email format is invalid");
    }
}