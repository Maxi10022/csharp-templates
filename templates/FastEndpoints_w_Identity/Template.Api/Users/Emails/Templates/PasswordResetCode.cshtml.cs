using Template.Api.Branding;

namespace Template.Api.Users.Emails.Templates;

public class PasswordResetCode
{
    public const string ViewName = "/Users/Emails/Templates/PasswordResetCode.cshtml";
    
    public required string ResetCode { get; init; }
    
    public required BrandingProvider Branding { get; init; }
}