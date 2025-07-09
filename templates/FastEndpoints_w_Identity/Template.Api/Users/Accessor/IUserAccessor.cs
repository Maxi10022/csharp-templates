namespace Template.Api.Users.Accessor;

public interface IUserAccessor
{
    public Task<User?> GetCurrentUser();
    
    public Guid? GetCurrentUserId();
}