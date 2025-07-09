# C# Templates

This is a template repository with some C# API templates.

## Available Templates

### 1. FastEndpoints with Identity and Marten

Requires a Postgres connection string, simplest way to get one is to [spin up a Docker instance](https://hub.docker.com/_/postgres).

Ideal for event sourced APIs with [ASP.NET Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=visual-studio) authentication. 

The Identity endpoints are ported to [FastEndpoints](https://fast-endpoints.com/) endpoints to integrate seamlessly with the auto-generated [NSwag documentation](https://github.com/RicoSuter/NSwag).  

#### Supported authentication methods are:

* Email & Password
* Google

Authentication scheme is configured for **cookies only**. 