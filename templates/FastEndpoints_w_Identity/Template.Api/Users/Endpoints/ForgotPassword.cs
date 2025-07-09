using System.Text;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace Template.Api.Users.Endpoints;

public sealed class ForgotPasswordRequest
{
    public string Email { get; set; } = null!;
}

public sealed class ForgotPasswordRequestValidator : Validator<ForgotPasswordRequest>
{
    public ForgotPasswordRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
} 

public class ForgotPasswordEndpoint(
    UserManager<User> userManager,
    IEmailSender<User> emailSender
) : Endpoint<ForgotPasswordRequest>
{
    public const string Name = "forgotPassword";

    public override void Configure()
    {
        Post("/users/forgot-password");
        AllowAnonymous();
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces(StatusCodes.Status200OK)
            .ProducesProblemFE()
        );
    }

    public override async Task HandleAsync(ForgotPasswordRequest req, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(req.Email);
        if (user is not null && await userManager.IsEmailConfirmedAsync(user))
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            await emailSender.SendPasswordResetCodeAsync(user, req.Email, code);
        }
        // Always return OK to avoid revealing user existence
        await SendOkAsync(ct);
    }
}
