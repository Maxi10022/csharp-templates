using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace Template.Api.Users.Endpoints;

public sealed class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}

public sealed class LoginEndpoint(
    SignInManager<User>  signInManager,
    ILogger<LoginEndpoint> logger
    ) : Endpoint<LoginRequest>
{
    public override void Configure()
    {
        Post("users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        signInManager.AuthenticationScheme = IdentityConstants.ApplicationScheme;

        var result = await signInManager.PasswordSignInAsync(req.Email, req.Password, isPersistent: true, lockoutOnFailure: true);

        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(req.TwoFactorCode))
            {
                result = await signInManager.TwoFactorAuthenticatorSignInAsync(req.TwoFactorCode, isPersistent: true, rememberClient: true);
            }
            else if (!string.IsNullOrEmpty(req.TwoFactorRecoveryCode))
            {
                result = await signInManager.TwoFactorRecoveryCodeSignInAsync(req.TwoFactorRecoveryCode);
            }
            else
            {
                ThrowError(x => x.TwoFactorCode, "Two-factor code required");
            }
        }

        if (!result.Succeeded)
        {
            logger.LogWarning($"Invalid login attempt {result}.");
            await SendUnauthorizedAsync(ct);
        }
    }
}