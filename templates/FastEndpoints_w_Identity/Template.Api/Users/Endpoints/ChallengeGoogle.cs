using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;

namespace Template.Api.Users.Endpoints;

public class ChallengeGoogleEndpoint : EndpointWithoutRequest
{
    public const string Name = "challengeGoogle";
    
    public override void Configure()
    {
        Get("/challenge/google");
        AllowAnonymous();
        Description(x => x
            .WithName(Name)
            .ClearDefaultProduces()
            .Produces(StatusCodes.Status302Found)
            .WithTags("Users")
        );    
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme);
        await SendRedirectAsync(HttpContext.Response.Headers.Location!, allowRemoteRedirects: true);
    }
}