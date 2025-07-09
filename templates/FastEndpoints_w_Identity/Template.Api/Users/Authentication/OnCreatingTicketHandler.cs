using System.Security.Claims;
using Marten;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Template.Api.Users.Events;
using Template.Api.Users.Persistence;

namespace Template.Api.Users.Authentication;

public sealed class OnCreatingTicketHandler(OAuthCreatingTicketContext context)
{
    private readonly UserDbContext _dbContext = 
        context.HttpContext.RequestServices.GetRequiredService<UserDbContext>();
    
    private readonly UserManager<User> _userManager = 
        context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
    
    private readonly IDocumentStore _documentStore = 
        context.HttpContext.RequestServices.GetRequiredService<IDocumentStore>();

    public async Task HandleAsync()
    {
        await using var documentSession = _documentStore.LightweightSession();

        var email = context.Identity?.FindFirst(ClaimTypes.Email)?.Value;

        if (string.IsNullOrWhiteSpace(email))
        {
            await RespondWithProblemAsync(OnCreatingTicketHandlerProblems.EmailNotProvidedByOAuthProvider);
            return;
        }

        var normalizedEmail = email.ToUpper();
        var user = await EntityFrameworkQueryableExtensions
            .FirstOrDefaultAsync(_dbContext.Users, user => user.NormalizedEmail == normalizedEmail);
        
        var loginInfo = ConstructGoogleLoginInfo();
        
        if (user is null)
        {
            user ??= new User();
            
            await _userManager.SetUserNameAsync(user, email);
            await _userManager.SetEmailAsync(user, email);
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                var problem = OnCreatingTicketHandlerProblems.FromIdentityResult(result);
                await RespondWithProblemAsync(problem);
                return;
            }
            
            await _userManager.AddLoginAsync(user, loginInfo);
            await ConfirmEmailAsync(user.Id);
    
            documentSession.Events.StartStream(user.Id, new UserRegistered());
            await documentSession.SaveChangesAsync();
        }
        else
        {
            var providerAvailable = _dbContext.UserLogins.Any(x => x.ProviderKey == loginInfo.ProviderKey);

            if (!providerAvailable)
            {
                await _userManager.AddLoginAsync(user, loginInfo);
            }
        }
    }

    private async Task ConfirmEmailAsync(Guid userId) => await _dbContext.Users
        .Where(x => x.Id == userId)
        .ExecuteUpdateAsync(calls => 
            calls.SetProperty(user => user.EmailConfirmed, true));

    private async Task RespondWithProblemAsync(ValidationProblemDetails problem)
    {
        context.Response.StatusCode = problem.Status!.Value;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problem);
    }
    
    private UserLoginInfo ConstructGoogleLoginInfo()
    {
        var externalUserId = context.Identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var loginProvider = context.Identity?.AuthenticationType;
        return new UserLoginInfo(loginProvider!, externalUserId!, GoogleDefaults.DisplayName);
    }
    
}