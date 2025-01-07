using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Api.Prices;

namespace Payments.Api.Products.Persistence;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        
        builder.HasKey(product => product.Id);
        
        builder.Property(product => product.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(product => product.StripeId)
            .HasColumnName("stripe_id")
            .IsRequired();
        
        builder.Property(product => product.Name)
            .HasColumnName("name")
            .IsRequired();
        
        builder.Property(product => product.Description)
            .HasColumnName("description");
        
        builder.Property(product => product.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        
        builder.Property(product => product.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
        
        builder.Property(product => product.Mode)
            .HasColumnName("mode")
            .IsRequired();
        
        builder.Property(product => product.Status)
            .HasColumnName("status")
            .IsRequired();

        builder.Property(product => product.DefaultPriceId)
            .HasColumnName("default_price_id");
    }
}