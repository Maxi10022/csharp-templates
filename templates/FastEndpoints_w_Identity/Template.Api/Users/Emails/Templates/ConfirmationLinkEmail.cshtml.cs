using Template.Api.Branding;

namespace Template.Api.Users.Emails.Templates;

public class ConfirmationLinkEmail 
{
    public const string ViewName = "/Users/Emails/Templates/ConfirmationLinkEmail.cshtml";
    
    public required string ConfirmationLink { get; init; } 
    
    public required BrandingProvider Branding { get; init; }
}