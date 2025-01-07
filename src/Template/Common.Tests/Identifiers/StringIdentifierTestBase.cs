using Common.Identifiers;

namespace Common.Tests.Identifiers;

public abstract class StringIdentifierTestBase<TIdentifier> 
    where TIdentifier : IIdentifier<TIdentifier, string>    
{
    [Fact]
    public void Parse_ShouldThrowArgumentNullException_WhenValueIsNull()
    {
        // Arrange
        string? invalidValue = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => TIdentifier.Parse(invalidValue));
    }

    [Fact]
    public void Parse_ShouldThrowArgumentException_WhenValueIsEmpty()
    {
        // Arrange
        string invalidValue = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => TIdentifier.Parse(invalidValue));
    }
    
    [Fact]
    public void TryParse_ShouldReturnFalseAndNull_WhenValueIsNull()
    {
        // Arrange
        string? invalidValue = null;

        // Act
        var success = TIdentifier.TryParse(invalidValue, out var stripeId);

        // Assert
        Assert.False(success);
        Assert.Null(stripeId);
    }

    [Fact]
    public void TryParse_ShouldReturnFalseAndNull_WhenValueIsEmpty()
    {
        // Arrange
        string invalidValue = "";

        // Act
        var success = TIdentifier.TryParse(invalidValue, out var stripeId);

        // Assert
        Assert.False(success);
        Assert.Null(stripeId);
    }
}