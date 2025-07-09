using FastEndpoints;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Template.Api.Users.Emails;
using Template.Api.Users.Passwords;

namespace Template.Api.Users.Endpoints.Manage;

public sealed class InfoRequestValidator : Validator<InfoRequest>
{
    public InfoRequestValidator()
    {
        When(x => x.NewEmail is not null, () =>
        {
            RuleFor(x => x.NewEmail)
                .EmailAddress();
        });

        When(x => x.NewPassword is not null, () =>
        {
            RuleFor(x => x.NewPassword)
                .SetValidator(new PasswordValidator()!);
            
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage("The old password is required to set a new password.");
        });
    }
}

public sealed class UpdateInfoEndpoint(
    UserManager<User> userManager,
    ILogger<UpdateInfoEndpoint> logger,
    ConfirmationEmailSender emailSender
) : Endpoint<InfoRequest, InfoResponse>
{
    public const string Name = "editAccountInfo";
    
    public override void Configure()
    {
        Post("/users/manage/info");
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces<InfoResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Manage")
        );
    }

    public override async Task HandleAsync(InfoRequest req, CancellationToken ct)
    {
        if (await userManager.GetUserAsync(HttpContext.User) is not { } user)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        

        if (!string.IsNullOrEmpty(req.NewPassword))
        {
            var changePasswordResult = await userManager.ChangePasswordAsync(user, req.OldPassword!, req.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                logger.LogError($"Error updating password: {string.Join(';', changePasswordResult.Errors)}");
                ThrowError("Failed to update password.");
            }
        }

        if (!string.IsNullOrEmpty(req.NewEmail))
        {
            var email = await userManager.GetEmailAsync(user);

            if (email != req.NewEmail)
            {
                await emailSender.SendConfirmationEmailAsync(user, HttpContext, req.NewEmail, isChange: true);
            }
        }

        var response = await CreateInfoResponseAsync(user, userManager);
        await SendOkAsync(response, ct);
    }
    
    private static async Task<InfoResponse> CreateInfoResponseAsync<TUser>(TUser user, UserManager<TUser> userManager)
        where TUser : class
    {
        return new()
        {
            Email = await userManager.GetEmailAsync(user) ?? throw new NotSupportedException("Users must have an email."),
            IsEmailConfirmed = await userManager.IsEmailConfirmedAsync(user),
        };
    }
} 