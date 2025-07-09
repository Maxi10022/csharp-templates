using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Template.Api.Users.Authentication;

public static class OnCreatingTicketHandlerProblems
{
    public static ValidationProblemDetails EmailNotProvidedByOAuthProvider => new()
    {
        Status = StatusCodes.Status400BadRequest,
        Detail = "Email was not provided by the OAuth provider, please contact support."
    };
    
    public static ValidationProblemDetails FromIdentityResult(IdentityResult result)
    {
        // We expect a single error code and description in the normal case.
        // This could be golfed with GroupBy and ToDictionary, but perf! :P
        Debug.Assert(!result.Succeeded);
        var errorDictionary = new Dictionary<string, string[]>(1);

        foreach (var error in result.Errors)
        {
            string[] newDescriptions;

            if (errorDictionary.TryGetValue(error.Code, out var descriptions))
            {
                newDescriptions = new string[descriptions.Length + 1];
                Array.Copy(descriptions, newDescriptions, descriptions.Length);
                newDescriptions[descriptions.Length] = error.Description;
            }
            else
            {
                newDescriptions = [error.Description];
            }

            errorDictionary[error.Code] = newDescriptions;
        }

        return new ValidationProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Errors = errorDictionary
        };
    }
}