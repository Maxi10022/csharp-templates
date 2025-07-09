using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;

namespace Template.Api.Common.Options;

public class FluentValidateOptions<TOptions>(
    IServiceProvider serviceProvider,
    string? optionsName
) : IValidateOptions<TOptions> where TOptions : class
{
    private readonly string _typeName = typeof(TOptions).Name;
    
    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        if (optionsName is not null && name != optionsName)
        {
            return ValidateOptionsResult.Skip;
        }
        
        ArgumentNullException.ThrowIfNull(options);
        
        using var scope = serviceProvider.CreateScope();
        
        var validators = scope.ServiceProvider.GetRequiredService<IValidator<TOptions>>();
        
        var result = validators.Validate(options);

        if (result.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        var errors = result.Errors
            .Select(FailureToString)
            .ToArray();
        
        return ValidateOptionsResult.Fail(errors);
    }

    private string FailureToString(ValidationFailure error) =>
        $"Validation failed for {_typeName}.{error.PropertyName} with the error: {error.ErrorMessage}";
}