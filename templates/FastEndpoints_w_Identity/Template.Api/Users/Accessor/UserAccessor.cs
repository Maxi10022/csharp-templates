using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Template.Api.Users.Accessor;

public sealed class UserAccessor(IHttpContextAccessor contextAccessor, UserManager<User> userManager) : IUserAccessor
{
    public async Task<User?> GetCurrentUser()
    {
        var context = contextAccessor.HttpContext;
        
        if (context is null) return null;
        
        return await userManager.GetUserAsync(context.User);
    }

    public Guid? GetCurrentUserId()
    {
        var context = contextAccessor.HttpContext;

        if (context is null) return null;

        var nameId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (Guid.TryParse(nameId, out var userId)) return userId;
        
        return null;
    }
}