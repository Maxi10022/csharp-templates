using Template.Api.Branding;
using Template.Api.Frontend;
using Template.Api.Marten;
using Template.Api.Users;
using FastEndpoints;
using FastEndpoints.Swagger;
using FluentValidation;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddMarten();

builder.Services
    .AddValidatorsFromAssemblyContaining<Program>()
    .AddUserAuthentication(builder.Configuration)
    .AddFrontendServices()
    .AddBrandingServices()
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen(options =>
    {
        options.Path = "/openapi/{documentName}.json";
    });

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapFastEndpoints();

app.Run();

public partial class Program;