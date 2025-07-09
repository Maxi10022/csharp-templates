using Microsoft.Extensions.Options;
using Template.Api.Frontend.Options;

namespace Template.Api.Frontend;

public class FrontendRouteProvider(IOptionsSnapshot<FrontendOptions> optionsSnapshot)
{
    private readonly FrontendOptions _options = optionsSnapshot.Value;

    public string EmailConfirmed => _options.Root + _options.Paths.EmailConfirmed;
    
    public string OAuthRedirect => _options.Root + _options.Paths.OAuthRedirect;
}