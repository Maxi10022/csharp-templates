# Introduction

This is a template repository with different opinionated csharp templates setup **web-apis** to get started immediatly. 

# Setup/Usage

1. First create your own repository from this template repo. 

2. Decide on a template you want to use, and if relevant, utility projects from the */src/utils* folder.

3. From the chosen template folder, copy its contents into the */src* folder.

4. Copy the utility projects, if any, from */src/utils/[Utility]* and */src/utils/[Utility].Tests* to the */src* folder. 

> Omit copying the *Template.sln* file. 

5. Delete all other template folders, as well as the */src/utils* folder, from the */src* folder. 

> Do not delete the copied files! 

6. Open the chosen templates */src/[Template].sln* file.

> Feel free to rename the solution! 

7. If you chose to add utility projects, add the utility projects as an *existing project* to your solution. 

8. Start developing! 

# Templates

Introducing the available templates with a short description.

## small-monolith

A template for getting started fast from a single project. 

Comes with the follwing pre-configured: 

* [FastEndpoints](https://fast-endpoints.com/) with [JWT-Bearer Auth](https://jwt.io/introduction)
* [EF-Core](https://learn.microsoft.com/de-de/ef/core/) with [PostgreSQL](https://www.npgsql.org/efcore/?tabs=onconfiguring)

# Utilities 

Contained within the */src/utils* folder. 

## Common

Contains some common [value-types](https://www.milanjovanovic.tech/blog/value-objects-in-dotnet-ddd-fundamentals), ready for use with EF-Core. 

Currently contains the *Email* value type and a simple interface for *strongly-typed identifiers*.  

For questions and suggestions feel free to open a *issue* for now, furhter documentation will come some time later. 

## Payments.Api 

Currently **not recommended** for use!

This utility project aims to introduce a *fluent* setup and configuration process in C# for [Stripe](https://stripe.com).

The main goal is to have a *code-first* approach for using [Stripe](https://stripe.com), 
this might be a spinoff for its own repo in the future if I decide to continue on with it. 

As mentioned the use is currently not recommended since it is not fully implemented yet.
