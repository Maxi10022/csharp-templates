using FastEndpoints;
using FastEndpoints.Swagger;
using Payments.Api.Persistence;
using Payments.Api.Stripe.Options;

var builder = WebApplication.CreateBuilder(args);

// TODO Add event handlers for: Customer, Product, Price, SubscriptionItem (compound with Subscription probably), Subscription, Meter (if available)
// TODO Create a fluent builder for creating a Price with Stripe
// TODO Figure out how to use the dockerized Stripe mock API for writing tests - test the test writing after implementing the first fluent builder 
// TODO Create fluent builders for the Stripe objects - new objects should (mostly) only be created from events builders should send the create calls
// TODO For each new feature immediately add tests! 
builder.Services
    .AddPaymentsDbContext()
    .AddStripeOptions()
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapFastEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.Run();