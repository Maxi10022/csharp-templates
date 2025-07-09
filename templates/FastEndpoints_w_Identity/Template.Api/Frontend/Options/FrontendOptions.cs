namespace Template.Api.Frontend.Options;

public sealed class FrontendOptions
{
    public string Root { get; init; } = null!;
    
    public Paths Paths { get; init; } = null!;
}