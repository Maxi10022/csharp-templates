using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payments.Api.Prices.Persistence;

internal sealed class PriceConfiguration : IEntityTypeConfiguration<PriceBase>
{
    public void Configure(EntityTypeBuilder<PriceBase> builder)
    {
        builder.UseTpcMappingStrategy();
        
        builder.HasKey(price => price.Id);
        
        builder.Property(price => price.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(price => price.StripeId)
            .HasColumnName("stripe_id")
            .IsRequired();
        
        builder.HasIndex(price => price.StripeId)
            .IsUnique();
        
        builder.Property(price => price.BillingScheme)
            .HasColumnName("billing_scheme")
            .IsRequired();
        
        builder.Property(price => price.TaxBehaviour)
            .HasColumnName("tax_behaviour")
            .IsRequired();
        
        builder.Property(price => price.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(price => price.Currency)
            .HasColumnName("currency")
            .IsRequired();
        
        builder.Property(price => price.Mode)
            .HasColumnName("mode")
            .IsRequired();
        
        builder.Property(price => price.Status)
            .HasColumnName("status")
            .IsRequired();
        
        builder.Property(price => price.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(price => price.UnitAmount)
            .HasColumnName("unit_amount");
        
        builder.Property(price => price.UnitAmountDecimal)
            .HasColumnName("unit_amount_decimal");

        builder.HasOne(price => price.Product)
            .WithOne(product => product.DefaultPrice)
            .HasForeignKey<PriceBase>(priceBase => priceBase.ProductId)
            .IsRequired();
    }
}