﻿using Microsoft.Extensions.Options;

namespace Template.Api.Common.Options;

public static class OptionsBuilderExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(
        this OptionsBuilder<TOptions> builder
    ) where TOptions : class
    {
        builder.Services.AddSingleton<IValidateOptions<TOptions>>(
            serviceProvider => new FluentValidateOptions<TOptions>(
            serviceProvider, builder.Name)
        );
        
        return builder;
    }
}