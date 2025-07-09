using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Template.Api.Users.Endpoints;

namespace Template.Api.Users.Emails;

public class ConfirmationEmailSender(
    UserManager<User> userManager,
    LinkGenerator linkGenerator,
    IEmailSender<User> emailSender
)
{
    public async Task SendConfirmationEmailAsync(User user, HttpContext context, string email, bool isChange = false)
    {
        var code = isChange
            ? await userManager.GenerateChangeEmailTokenAsync(user, email)
            : await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        var userId = await userManager.GetUserIdAsync(user);
        var routeValues = new RouteValueDictionary()
        {
            ["userId"] = userId,
            ["code"] = code,
        };

        if (isChange)
        {
            // This is validated by the /confirmEmail endpoint on change.
            routeValues.Add("changedEmail", email);
        }

        var confirmEmailUrl = linkGenerator.GetUriByName(context, ConfirmEmailEndpoint.Name, routeValues);

        await emailSender.SendConfirmationLinkAsync(user, email, HtmlEncoder.Default.Encode(confirmEmailUrl!));
    }
}