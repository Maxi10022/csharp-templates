using Common.Tests.Identifiers;
using Payments.Api.Stripe;

namespace Payments.Api.Tests.Stripe;

public class StripeIdTests : StringIdentifierTestBase<StripeId>
{
    [Fact]
    public void From_ShouldCreateStripeId_WhenValueIsValid()
    {
        // Arrange
        string validValue = "valid-id";

        // Act
        var stripeId = StripeId.From(validValue);

        // Assert
        Assert.NotNull(stripeId);
        Assert.Equal(validValue, stripeId.Value);
    }

    [Fact]
    public void Parse_ShouldReturnStripeId_WhenValueIsValid()
    {
        // Arrange
        string validValue = "valid-id";

        // Act
        var stripeId = StripeId.Parse(validValue);

        // Assert
        Assert.NotNull(stripeId);
        Assert.Equal(validValue, stripeId.Value);
    }

    [Fact]
    public void TryParse_ShouldReturnTrueAndStripeId_WhenValueIsValid()
    {
        // Arrange
        string validValue = "valid-id";

        // Act
        var success = StripeId.TryParse(validValue, out var stripeId);

        // Assert
        Assert.True(success);
        Assert.NotNull(stripeId);
        Assert.Equal(validValue, stripeId!.Value);
    }

    [Fact]
    public void Create_ShouldThrowNotSupportedException()
    {
        // Act & Assert
        Assert.Throws<NotSupportedException>(StripeId.Create);
    }
}