using FastEndpoints;
using FastEndpoints.Swagger;
using QuickMail.Api.Authentication;
using QuickMail.Api.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddJwtAuthentication(configuration)
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument()
    .AddAppDbContext();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen(options =>
    {
        options.Path = "openapi/{documentName}.json";
    });
    
    app.MapScalarApiReference();
}

app.UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints();

app.Run();