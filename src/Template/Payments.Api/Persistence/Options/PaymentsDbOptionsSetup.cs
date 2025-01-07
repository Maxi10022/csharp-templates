using FluentValidation;
using Microsoft.Extensions.Options;

namespace Payments.Api.Persistence.Options;

internal sealed class PaymentsDbOptionsSetup : IConfigureOptions<PaymentsDbOptions>
{
    public const string SectionName = "ConnectionStrings";
    
    private readonly IConfiguration _configuration;
    private readonly IValidator<PaymentsDbOptions> _validator;

    public PaymentsDbOptionsSetup(
        IConfiguration configuration, 
        IValidator<PaymentsDbOptions> validator)
    {
        _configuration = configuration;
        _validator = validator;
    }

    public void Configure(PaymentsDbOptions options)
    {
        _configuration
            .GetRequiredSection(SectionName)
            .Bind(options);
        
        _validator.ValidateAndThrow(options);
    }
}