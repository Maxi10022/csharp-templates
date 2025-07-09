using Template.Api.Users.Emails;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Template.Api.Users.Accessor;
using Template.Api.Users.Authentication;
using Template.Api.Users.Persistence;

namespace Template.Api.Users;

public static class UserAuthenticationConfiguration
{
    public static IServiceCollection AddUserAuthentication(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddAuthentication()
            .AddOAuth<GoogleOptions, CustomGoogleHandler>(
                GoogleDefaults.AuthenticationScheme, 
                GoogleDefaults.DisplayName, 
                options =>
                {
                    options.SignInScheme = IdentityConstants.ApplicationScheme;
                    options.CallbackPath = new PathString("/google/callback");
                    
                    options.ClientId = configuration["OAuth:Google:ClientId"]!;
                    ArgumentException.ThrowIfNullOrWhiteSpace(options.ClientId);
                    
                    options.ClientSecret = configuration["OAuth:Google:Secret"]!;;
                    ArgumentException.ThrowIfNullOrWhiteSpace(options.ClientSecret);
                    
                    options.Events.OnCreatingTicket = OnCreatingTicket.Handle;
                }
            );
        
        services.AddHttpContextAccessor();
        
        services.AddScoped<IUserAccessor, UserAccessor>();
        
        services.AddAuthorization()
            .AddEmailSender()
            .AddIdentityDbContext(configuration)
            .AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<UserDbContext>();
        
        return services;
    }
}