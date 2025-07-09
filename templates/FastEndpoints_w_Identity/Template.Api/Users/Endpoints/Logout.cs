using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Template.Api.Users.Endpoints;

public sealed class LogoutEndpoint : EndpointWithoutRequest
{
    public const string Name = "logout";
    
    public override void Configure()
    {
        Post("/users/logout");
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces(StatusCodes.Status200OK)
        );    
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
        await SendOkAsync(ct);
    }
}