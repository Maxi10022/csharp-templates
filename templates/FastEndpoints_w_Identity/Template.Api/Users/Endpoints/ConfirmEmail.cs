using System.Text;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Template.Api.Frontend;

namespace Template.Api.Users.Endpoints;

public sealed class ConfirmEmailRequest
{
    [BindFrom("userId"), QueryParam]
    public string UserId { get; init; } = null!;

    [BindFrom("code"), QueryParam]
    public string Code { get; set; } = null!;
    
    [BindFrom("changedEmail"), QueryParam]
    public string? ChangedEmail { get; init; }
}

public class ConfirmEmailEndpoint(
    FrontendRouteProvider routeProvider, 
    UserManager<User> userManager
) : Endpoint<ConfirmEmailRequest>
{
    public const string Name = "confirmEmail";
    
    public override void Configure()
    {
        Get("/users/confirm-email");
        AllowAnonymous();
        Description(builder => builder
            .WithName(Name)
            .ClearDefaultAccepts()
            .Accepts<ConfirmEmailRequest>()
            .ClearDefaultProduces()
            .Produces(StatusCodes.Status302Found)
            .Produces(StatusCodes.Status401Unauthorized)
        );
    }

    public override async Task HandleAsync(ConfirmEmailRequest req, CancellationToken ct)
    {
        if (await userManager.FindByIdAsync(req.UserId) is not { } user)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        try
        {
            req.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(req.Code));
        }
        catch (FormatException)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        IdentityResult result;

        if (string.IsNullOrEmpty(req.ChangedEmail))
        {
            result = await userManager.ConfirmEmailAsync(user, req.Code);
        }
        else
        {
            // As with Identity UI, email and user name are one and the same. So when we update the email,
            // we need to update the user name.
            result = await userManager.ChangeEmailAsync(user, req.ChangedEmail, req.Code);

            if (result.Succeeded)
            {
                result = await userManager.SetUserNameAsync(user, req.ChangedEmail);
            }
        }

        if (!result.Succeeded)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        await SendRedirectAsync(routeProvider.EmailConfirmed, allowRemoteRedirects: true);
    }
}