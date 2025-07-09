using Microsoft.AspNetCore.Identity;

namespace Template.Api.Users;

public sealed class User : IdentityUser<Guid>;

public sealed class UserRole : IdentityRole<Guid>;