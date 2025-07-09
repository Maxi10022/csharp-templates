using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace Template.Api.Users.Endpoints.Manage;

public sealed class GetInfoEndpoint(
    UserManager<User> userManager
) : EndpointWithoutRequest<InfoResponse>
{
    public const string Name = "getAccountInfo";
    
    public override void Configure()
    {
        Get("/users/manage/info");
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces<InfoResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Manage")
        );
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        if (await userManager.GetUserAsync(HttpContext.User) is not { } user)
        {
            await SendNotFoundAsync(ct);
            return;
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