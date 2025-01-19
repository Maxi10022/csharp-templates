using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Api.Customers;

namespace Payments.Api.Meters.Persistence;

internal sealed class MeterConfiguration : IEntityTypeConfiguration<Meter>
{
    public void Configure(EntityTypeBuilder<Meter> builder)
    {
        builder.ToTable("meters");
        
        builder.HasKey(meter => meter.Id);
        
        builder.Property(meter => meter.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(meter => meter.StripeId)
            .HasColumnName("stripe_id")
            .IsRequired();
        
        builder.HasIndex(meter => meter.StripeId)
            .IsUnique();
        
        builder.ComplexProperty(meter => meter.Timestamps, propertyBuilder =>
        {
            propertyBuilder.Property(timestamps => timestamps.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            
            propertyBuilder.Property(timestamps => timestamps.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
        });
        
        builder.Property(meter => meter.CustomerId)
            .HasColumnName("customer_id")
            .IsRequired();
        
        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(meter => meter.CustomerId);
        
        builder.Property(meter => meter.DisplayName)
            .HasColumnName("display_name")
            .IsRequired();

        builder.ComplexProperty(meter => meter.Event, propertyBuilder =>
        {
            propertyBuilder.Property(meterEvent => meterEvent.Name)
                .HasColumnName("event_name")
                .IsRequired();

            propertyBuilder.Property(meter => meter.TimeWindow)
                .HasColumnName("time_window");
        });

        builder.ComplexProperty(meter => meter.StatusTransitions, propertyBuilder =>
        {
            propertyBuilder.Property(transitions => transitions.DeactivatedAt)
                .HasColumnName("deactivated_at");
        });
        
        builder.ComplexProperty(meter => meter.ValueSettings, propertyBuilder =>
        {
            propertyBuilder.Property(valueSettings => valueSettings.EventPayloadKey)
                .HasColumnName("event_payload_key")
                .IsRequired();
        });
    }
}