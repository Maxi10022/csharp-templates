using Microsoft.EntityFrameworkCore;

namespace Template.Api.Users.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddIdentityDbContext(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
        
        services.AddDbContext<UserDbContext>(opts => 
            opts.UseNpgsql(connectionString)
        );
        
        return services;
    }
}