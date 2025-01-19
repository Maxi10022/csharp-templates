using Microsoft.EntityFrameworkCore;

namespace QuickMail.Api.Persistence;

internal sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}