using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Text;
using System.Text.Encodings.Web;
using FastEndpoints;
using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.WebUtilities;
using Template.Api.Users.Emails;
using Template.Api.Users.Events;
using Template.Api.Users.Passwords;

namespace Template.Api.Users.Endpoints;

public sealed class RegisterRequestValidator : Validator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .SetValidator(new PasswordValidator());
    }
}

public sealed class RegisterEndpoint(
    IDocumentStore documentStore,
    UserManager<User> userManager,
    IUserStore<User> userStore,
    LinkGenerator linkGenerator,
    ILogger<RegisterEndpoint> logger,
    ConfirmationEmailSender emailSender
) : Endpoint<RegisterRequest>
{
    public const string Name = "register";
    
    public override void Configure()
    {
        Tags("Users");
        Post("/users/register");
        AllowAnonymous();
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces(StatusCodes.Status200OK)
            .ProducesProblemFE()
        );
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        await using var documentSession = documentStore.LightweightSession();
            
        if (!userManager.SupportsUserEmail)
        {
            throw new NotSupportedException($"{nameof(RegisterEndpoint)} requires a user store with email support.");
        }

        var emailStore = (IUserEmailStore<User>)userStore;
        var email = req.Email;

        var user = new User();
        await userStore.SetUserNameAsync(user, email, CancellationToken.None);
        await emailStore.SetEmailAsync(user, email, CancellationToken.None);
        var result = await userManager.CreateAsync(user, req.Password);

        if (!result.Succeeded)
        {
            logger.LogError($"Failed to register user, {string.Join(';', result.Errors)}");
            ThrowError("Failed to register user.");
            return;
        }

        documentSession.Events.StartStream((user as User)!.Id, new UserRegistered());
        await documentSession.SaveChangesAsync(ct);
            
        await emailSender.SendConfirmationEmailAsync(user, HttpContext, email);
        
        await SendOkAsync(ct);
    }
}