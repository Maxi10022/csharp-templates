using System.Text;
using System.Text.Encodings.Web;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Template.Api.Users.Emails;

namespace Template.Api.Users.Endpoints;

public sealed class ResendConfirmationEmailRequest
{
    [BindFrom("email"), QueryParam]
    public string Email { get; set; } = null!;
}

public class ResendConfirmationEmailEndpoint(
    UserManager<User> userManager,
    ConfirmationEmailSender emailSender
) : Endpoint<ResendConfirmationEmailRequest>
{
    public const string Name = "resendConfirmationEmail";

    public override void Configure()
    {
        Post("/users/resend-confirmation-email");
        AllowAnonymous();
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces(StatusCodes.Status200OK)
        );
    }

    public override async Task HandleAsync(ResendConfirmationEmailRequest req, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(req.Email);
        if (user is not null)
        {
            await emailSender.SendConfirmationEmailAsync(user, HttpContext, req.Email);
        }
        await SendOkAsync(ct);
    }
}
