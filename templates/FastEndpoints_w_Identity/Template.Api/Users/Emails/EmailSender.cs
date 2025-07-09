using System.Net;
using System.Net.Mail;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Razor.Templating.Core;
using Template.Api.Branding;
using Template.Api.Users.Emails.Options;
using Template.Api.Users.Emails.Templates;

namespace Template.Api.Users.Emails;

public class EmailSender(
    BrandingProvider brandingProvider, 
    IOptions<EmailOptions> options
) : IEmailSender<User>
{
    private readonly EmailOptions _options = options.Value;
    
    public async Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        var decodedConfirmationLink = HttpUtility.HtmlDecode(confirmationLink);
        
        var emailTemplate = await RazorTemplateEngine.RenderPartialAsync(
            ConfirmationLinkEmail.ViewName,
            new ConfirmationLinkEmail
            {
                Branding = brandingProvider,
                ConfirmationLink = decodedConfirmationLink,
            }
        );

        using var client = CreateSmtpClient();

        var message = new MailMessage
        {
            To = { email },
            From = new MailAddress(_options.Username),
            Subject = "Email confirmation",
            Body = emailTemplate,
            IsBodyHtml = true,
        };
        
        await client.SendMailAsync(message);
    }

    public async Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        var decodedResetLink = HttpUtility.HtmlDecode(resetLink);
        
        var emailTemplate = await RazorTemplateEngine.RenderPartialAsync(
            PasswordResetLink.ViewName,
            new PasswordResetLink
            {
                Branding = brandingProvider,
                ResetLink = decodedResetLink,
            }
        );

        using var client = CreateSmtpClient();

        var message = new MailMessage
        {
            To = { email },
            From = new MailAddress(_options.Username),
            Subject = "Password reset link",
            Body = emailTemplate,
            IsBodyHtml = true,
        };
        
        await client.SendMailAsync(message);
    }

    public async Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        var decodedResetCode = HttpUtility.HtmlDecode(resetCode);
        
        var emailTemplate = await RazorTemplateEngine.RenderPartialAsync(
            PasswordResetCode.ViewName,
            new PasswordResetCode
            {
                Branding = brandingProvider,
                ResetCode = decodedResetCode,
            }
        );

        using var client = CreateSmtpClient();

        var message = new MailMessage
        {
            To = { email },
            From = new MailAddress(_options.Username),
            Subject = "Password reset code",
            Body = emailTemplate,
            IsBodyHtml = true,
        };
        
        await client.SendMailAsync(message);
    }
    
    private SmtpClient CreateSmtpClient()
    {
        var smtpClient = new SmtpClient(_options.Server, _options.Port);
        
        smtpClient.Credentials = new NetworkCredential(_options.Username, _options.Password);
        
        smtpClient.EnableSsl = _options.EnableSsl;
        
        return smtpClient;
    }
}