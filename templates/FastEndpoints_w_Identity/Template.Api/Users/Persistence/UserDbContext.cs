using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Template.Api.Users.Persistence;

public class UserDbContext(
    DbContextOptions<UserDbContext> options
) : IdentityDbContext<User, UserRole, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("identity");
        
        base.OnModelCreating(builder);
    }
}