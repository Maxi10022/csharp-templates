namespace Template.Api.Users.Emails.Options;

public class EmailOptions
{
    public string Server { get; init; } = null!;
    
    public int Port { get; init; }
    
    public string Username { get; init; } = null!;
    
    public string Password { get; init; } = null!;
    
    public bool EnableSsl { get; init; }
}