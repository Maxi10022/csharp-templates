using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Api.Meters;

namespace Payments.Api.Prices.Persistence;

internal sealed class RecurringPriceConfiguration : IEntityTypeConfiguration<RecurringPrice>
{
    public void Configure(EntityTypeBuilder<RecurringPrice> builder)
    {
        builder.ToTable("recurring_prices");

        builder.Property(price => price.AggregateUsage)
            .HasColumnName("aggregate_usage");
        
        builder.Property(price => price.Interval)
            .HasColumnName("interval")
            .IsRequired();
        
        builder.Property(price => price.MeterId)
            .HasColumnName("meter_id");
        
        builder.Property(price => price.IntervalCount)
            .HasColumnName("interval_count")
            .IsRequired();

        builder.HasOne<Meter>()
            .WithOne()
            .HasForeignKey<RecurringPrice>(price => price.MeterId);
        
        builder.HasIndex(price => price.MeterId);
        
        builder.Property(price => price.UsageType)
            .HasColumnName("usage_type")
            .IsRequired();
    }
}