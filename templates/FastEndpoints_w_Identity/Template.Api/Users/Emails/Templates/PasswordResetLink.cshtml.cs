using Template.Api.Branding;

namespace Template.Api.Users.Emails.Templates;

public class PasswordResetLink
{
    public const string ViewName = "/Users/Emails/Templates/PasswordResetLink.cshtml";
    
    public required string ResetLink { get; init; }
    
    public required BrandingProvider Branding { get; init; }
}