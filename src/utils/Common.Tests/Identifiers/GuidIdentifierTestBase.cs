using Common.Identifiers;

namespace Common.Tests.Identifiers;

public abstract class GuidIdentifierTestBase<TIdentifier> 
    where TIdentifier : IIdentifier<TIdentifier, Guid>    
{
    [Fact]
    public virtual void From_ShouldCreateIdentifier_WhenGuidIsValid()
    {
        // Arrange
        Guid validGuid = Guid.NewGuid();

        // Act
        var subscriptionId = TIdentifier.From(validGuid);

        // Assert
        Assert.NotNull(subscriptionId);
        Assert.Equal(validGuid, subscriptionId.Value);
    }

    [Fact]
    public virtual void Create_ShouldGenerateNewIdentifier()
    {
        // Act
        var subscriptionId = TIdentifier.Create();

        // Assert
        Assert.NotNull(subscriptionId);
        Assert.NotEqual(Guid.Empty, subscriptionId.Value);
    }

    [Fact]
    public virtual void Parse_ShouldReturnIdentifier_WhenValueIsValidGuidString()
    {
        // Arrange
        string validGuidString = Guid.NewGuid().ToString();

        // Act
        var subscriptionId = TIdentifier.Parse(validGuidString);

        // Assert
        Assert.NotNull(subscriptionId);
        Assert.Equal(Guid.Parse(validGuidString), subscriptionId.Value);
    }

    [Fact]
    public virtual void Parse_ShouldThrowArgumentNullException_WhenValueIsNull()
    {
        // Arrange
        string? invalidValue = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => TIdentifier.Parse(invalidValue));
    }

    [Fact]
    public virtual void Parse_ShouldThrowFormatException_WhenValueIsInvalidGuidString()
    {
        // Arrange
        string invalidValue = "invalid-guid";

        // Act & Assert
        Assert.Throws<FormatException>(() => TIdentifier.Parse(invalidValue));
    }

    [Fact]
    public virtual void TryParse_ShouldReturnTrueAndIdentifier_WhenValueIsValidGuidString()
    {
        // Arrange
        string validGuidString = Guid.NewGuid().ToString();

        // Act
        var success = TIdentifier.TryParse(validGuidString, out var subscriptionId);

        // Assert
        Assert.True(success);
        Assert.NotNull(subscriptionId);
        Assert.Equal(Guid.Parse(validGuidString), subscriptionId.Value);
    }

    [Fact]
    public virtual void TryParse_ShouldReturnFalseAndDefault_WhenValueIsNull()
    {
        // Arrange
        string? invalidValue = null;

        // Act
        var success = TIdentifier.TryParse(invalidValue, out var subscriptionId);

        // Assert
        Assert.False(success);
        Assert.Equal(default, subscriptionId);
    }

    [Fact]
    public virtual void TryParse_ShouldReturnFalseAndDefault_WhenValueIsInvalidGuidString()
    {
        // Arrange
        string invalidValue = "invalid-guid";

        // Act
        var success = TIdentifier.TryParse(invalidValue, out var subscriptionId);

        // Assert
        Assert.False(success);
        Assert.Equal(default, subscriptionId);
    }
}