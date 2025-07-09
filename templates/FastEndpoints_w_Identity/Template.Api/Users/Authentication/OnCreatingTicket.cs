using Microsoft.AspNetCore.Authentication.OAuth;

namespace Template.Api.Users.Authentication;

public static class OnCreatingTicket
{
    public static readonly Func<OAuthCreatingTicketContext, Task> Handle = async (context) =>
    {
        var handler = new OnCreatingTicketHandler(context);
        await handler.HandleAsync();
    };
}