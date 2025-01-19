using Common.Emails;

namespace Common.Tests.Emails;

public class EmailTests
{
    [Fact]
    public void Create_WithValidEmail_ReturnsEmailObject()
    {
        // Arrange
        var validEmail = "test@example.com";

        // Act
        var email = Email.Create(validEmail);

        // Assert
        Assert.NotNull(email);
        Assert.Equal(validEmail, email.Value);
    }

    [Theory]
    [InlineData("invalidEmail")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("missingAtSign.com")]
    public void Create_WithInvalidEmail_ThrowsInvalidDataException(string invalidEmail)
    {
        // Arrange & Act & Assert
        Assert.Throws<InvalidDataException>(() => Email.Create(invalidEmail));
    }

    [Fact]
    public void Emails_WithSameValue_AreEqual()
    {
        // Arrange
        var email1 = Email.Create("test@example.com");
        var email2 = Email.Create("test@example.com");

        // Act & Assert
        Assert.Equal(email1, email2);
        Assert.True(email1 == email2);
    }

    [Fact]
    public void Emails_WithDifferentValues_AreNotEqual()
    {
        // Arrange
        var email1 = Email.Create("test1@example.com");
        var email2 = Email.Create("test2@example.com");

        // Act & Assert
        Assert.NotEqual(email1, email2);
        Assert.True(email1 != email2);
    }

}