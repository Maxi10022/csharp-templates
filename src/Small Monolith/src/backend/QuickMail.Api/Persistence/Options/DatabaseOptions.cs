namespace QuickMail.Api.Persistence.Options;

internal sealed class DatabaseOptions
{
    [ConfigurationKeyName("DefaultConnection")]
    public string ConnectionString { get; init; } = null!;
}