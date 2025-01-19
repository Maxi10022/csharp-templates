using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payments.Api.SubscriptionItems.Persistence;

internal sealed class SubscriptionItemConfiguration : IEntityTypeConfiguration<SubscriptionItem>
{
    public void Configure(EntityTypeBuilder<SubscriptionItem> builder)
    {
        builder.ToTable("subscription_items");
        
        builder.HasKey(item => item.Id);

        builder.Property(item => item.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(item => item.PriceId)
            .HasColumnName("price_id")
            .IsRequired();
        
        builder.Property(item => item.StripeId)
            .HasColumnName("stripe_id")
            .IsRequired();
        
        builder.Property(item => item.SubscriptionId)
            .HasColumnName("subscription_id")
            .IsRequired();
        
        builder.Property(item => item.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(item => item.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.HasOne(item => item.Price)
            .WithMany()
            .HasForeignKey(item => item.PriceId)
            .IsRequired();
        
        builder.HasOne(item => item.Subscription)
            .WithMany()
            .HasForeignKey(item => item.SubscriptionId)
            .IsRequired();
    }
}