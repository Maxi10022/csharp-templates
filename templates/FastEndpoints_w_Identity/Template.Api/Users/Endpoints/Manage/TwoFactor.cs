using System.Security.Claims;
using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace Template.Api.Users.Endpoints.Manage;

public sealed class TwoFactorRequestValidator : Validator<TwoFactorRequest>
{
    public TwoFactorRequestValidator()
    {
        When(x => x.Enable == true, () =>
        {
            RuleFor(x => x.ResetSharedKey)
                .Equal(false)
                .WithMessage("Cannot reset shared key and enable 2FA at the same time.");
            
            RuleFor(x => x.TwoFactorCode)
                .NotEmpty()
                .WithMessage("2FA code required to enable 2FA.");
        });
    }
}

public class TwoFactorEndpoint(
    SignInManager<User> signInManager
) : Endpoint<TwoFactorRequest, TwoFactorResponse>
{
    public const string Name = "manageTwoFactor";

    public override void Configure()
    {
        Post("/users/manage/2fa");
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces<TwoFactorResponse>()
            .ProducesProblemFE()
            .WithTags("Manage")
        );
    }

    public override async Task HandleAsync(TwoFactorRequest req, CancellationToken ct)
    {
        var userManager = signInManager.UserManager;
        var user = await userManager.GetUserAsync(User as ClaimsPrincipal);
        if (user is null)
        {
            ThrowError("User not found.");
            return;
        }
        
        if (req.Enable == true)
        {
            if (!await userManager.VerifyTwoFactorTokenAsync(user, userManager.Options.Tokens.AuthenticatorTokenProvider, req.TwoFactorCode!))
            {
                ThrowError(x => x.TwoFactorCode, "A valid 2fa token is required to enable 2fa.");
                return;
            }
            await userManager.SetTwoFactorEnabledAsync(user, true);
        }
        else if (req.Enable == false || req.ResetSharedKey)
        {
            await userManager.SetTwoFactorEnabledAsync(user, false);
        }
        if (req.ResetSharedKey)
        {
            await userManager.ResetAuthenticatorKeyAsync(user);
        }
        string[]? recoveryCodes = null;
        if (req.ResetRecoveryCodes || (req.Enable == true && await userManager.CountRecoveryCodesAsync(user) == 0))
        {
            var recoveryCodesEnumerable = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            recoveryCodes = recoveryCodesEnumerable?.ToArray();
        }
        if (req.ForgetMachine)
        {
            await signInManager.ForgetTwoFactorClientAsync();
        }
        var key = await userManager.GetAuthenticatorKeyAsync(user);
        if (string.IsNullOrEmpty(key))
        {
            await userManager.ResetAuthenticatorKeyAsync(user);
            key = await userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrEmpty(key))
            {
                ThrowError("Authenticator key could not be generated.");
                return;
            }
        }
        var response = new TwoFactorResponse
        {
            SharedKey = key,
            RecoveryCodes = recoveryCodes,
            RecoveryCodesLeft = recoveryCodes?.Length ?? await userManager.CountRecoveryCodesAsync(user),
            IsTwoFactorEnabled = await userManager.GetTwoFactorEnabledAsync(user),
            IsMachineRemembered = await signInManager.IsTwoFactorClientRememberedAsync(user)
        };
        await SendOkAsync(response, cancellation: ct);
    }
}
