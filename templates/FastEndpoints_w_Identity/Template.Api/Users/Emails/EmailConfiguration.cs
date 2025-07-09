using Template.Api.Common.Options;
using Microsoft.AspNetCore.Identity;
using Template.Api.Users.Emails.Options;

namespace Template.Api.Users.Emails;

public static class EmailConfiguration
{
    public static IServiceCollection AddEmailSender(this IServiceCollection services)
    {
        services.AddTransient<IEmailSender<User>, EmailSender>();
        services.AddOptionsWithFluentValidation<EmailOptions>("Smtp");
        services.AddScoped<ConfirmationEmailSender>();

        return services;
    }
}