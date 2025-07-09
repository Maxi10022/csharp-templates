using System.Text;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Template.Api.Users.Passwords;

namespace Template.Api.Users.Endpoints;

public sealed class ResetPasswordRequest
{
    public string Email { get; init; } = null!;
    public string ResetCode { get; init; } = null!;
    public string NewPassword { get; init; } = null!;
}

public sealed class ResetPasswordRequestValidator : Validator<ResetPasswordRequest>
{
    public ResetPasswordRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.ResetCode)
            .NotEmpty();
        
        RuleFor(x => x.NewPassword)
            .SetValidator(new PasswordValidator());
    }
}

public class ResetPasswordEndpoint(
    UserManager<User> userManager,
    ILogger<ResetPasswordEndpoint> logger
) : Endpoint<ResetPasswordRequest>
{
    public const string Name = "resetPassword";

    public override void Configure()
    {
        Post("/users/reset-password");
        AllowAnonymous();
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces(StatusCodes.Status200OK)
            .ProducesProblemFE()
        );
    }

    public override async Task HandleAsync(ResetPasswordRequest req, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(req.Email);
        
        if (user is null || !(await userManager.IsEmailConfirmedAsync(user)))
        {
            ThrowError(x => x.ResetCode, "Invalid reset code.");
        }
        
        IdentityResult result;
        try
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(req.ResetCode));
            result = await userManager.ResetPasswordAsync(user, code, req.NewPassword);
        }
        catch (FormatException)
        {
            ThrowError(x => x.ResetCode, "Invalid reset code.");
            return;
        }
        if (!result.Succeeded)
        {
            logger.LogError($"Reset password failed for {req.Email} with: {string.Join(';', result.Errors)}");
            ThrowError("Failed to reset password.");
        }
        await SendOkAsync(ct);
    }
}
