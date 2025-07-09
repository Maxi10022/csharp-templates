using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Options;
using Template.Api.Frontend;

namespace Template.Api.Users.Authentication;

public class CustomGoogleHandler : GoogleHandler
{
    [Obsolete("Obsolete")]
    public CustomGoogleHandler(
        IOptionsMonitor<GoogleOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock) { }

    public CustomGoogleHandler(
        IOptionsMonitor<GoogleOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder) : base(options, logger, encoder) { }

    protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
    {
        var routeProvider = Context.RequestServices.GetRequiredService<FrontendRouteProvider>();
        var ticket = await base.CreateTicketAsync(identity, properties, tokens);
        ticket.Properties.RedirectUri = routeProvider.OAuthRedirect;
        return ticket;
    }
}