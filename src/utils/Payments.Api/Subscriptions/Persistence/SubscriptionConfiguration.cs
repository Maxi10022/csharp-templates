using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Api.Customers;

namespace Payments.Api.Subscriptions.Persistence;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("subscriptions");
        
        builder.HasKey(subscription => subscription.Id);
        
        builder.Property(subscription => subscription.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(subscription => subscription.StripeId)
            .HasColumnName("stripe_id")
            .IsRequired();
        
        builder.Property(subscription => subscription.CustomerId)
            .HasColumnName("customer_id")
            .IsRequired();
        
        builder.Property(subscription => subscription.Status)
            .HasColumnName("status")
            .IsRequired();
        
        builder.Property(subscription => subscription.Currency)
            .HasColumnName("currency")
            .IsRequired();
        
        builder.Property(subscription => subscription.CurrentPeriodEnd)
            .HasColumnName("current_period_end")
            .IsRequired();
        
        builder.Property(subscription => subscription.CurrentPeriodStart)
            .HasColumnName("current_period_start")
            .IsRequired();

        builder.Property(subscription => subscription.CancelAt)
            .HasColumnName("cancel_at");

        builder.HasMany(subscription => subscription.SubscriptionItems)
            .WithOne(item => item.Subscription)
            .HasForeignKey(item => item.SubscriptionId);

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(subscription => subscription.CustomerId)
            .IsRequired();
    }
}