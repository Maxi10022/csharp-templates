using Common.Emails;
using Common.Identifiers.Persistence;
using Common.ValueTypes.Persistence;
using Microsoft.EntityFrameworkCore;
using Payments.Api.Customers;
using Payments.Api.Meters;
using Payments.Api.Meters.Persistence;
using Payments.Api.Prices;
using Payments.Api.Prices.Persistence;
using Payments.Api.Products;
using Payments.Api.Products.Persistence;
using Payments.Api.Stripe.Persistence;
using Payments.Api.SubscriptionItems;
using Payments.Api.SubscriptionItems.Persistence;
using Payments.Api.Subscriptions;
using Payments.Api.Subscriptions.Persistence;

namespace Payments.Api.Persistence;

internal sealed class PaymentsDbContext : DbContext
{
    public const string Schema = "payments";
    
    public DbSet<Customer> Customers { get; init; }
    
    public DbSet<Meter> Meters { get; init; }
    
    public DbSet<PriceBase> Prices { get; init; }
    
    public DbSet<RecurringPrice> RecurringPrices { get; init; }
    
    public DbSet<FixedPrice> FixedPrices { get; init; }
    
    public DbSet<Product> Products { get; init; }
    
    public DbSet<SubscriptionItem> SubscriptionItems { get; init; }
    
    public DbSet<Subscription> Subscriptions { get; init; }
    
    public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) : base(options) { }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .ConfigureCommonStripeConventions()
            .ConfigureMeterConventions()
            .ConfigurePriceConventions()
            .ConfigureProductConventions()
            .ConfigureSubscriptionItemConventions()
            .ConfigureSubscriptionConventions();
        
        configurationBuilder.Properties<CustomerId>()
            .HaveConversion<GuidIdentityValueConverter<CustomerId>>();
        
        configurationBuilder.Properties<SubscriptionId>()
            .HaveConversion<GuidIdentityValueConverter<SubscriptionId>>();
        
        configurationBuilder.Properties<Email>()
            .HaveConversion<StringValueConverter<Email>>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentsDbContext).Assembly);
    }
}