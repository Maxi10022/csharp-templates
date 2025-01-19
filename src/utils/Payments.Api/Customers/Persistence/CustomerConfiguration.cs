using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payments.Api.Customers.Persistence;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");
        
        builder.HasKey(customer => customer.Id);
        
        builder.Property(customer => customer.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(customer => customer.StripeId)
            .HasColumnName("stripe_id")
            .IsRequired();
        
        builder.Property(customer => customer.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(customer => customer.Name)
            .HasColumnName("name");
        
        builder.HasIndex(customer => customer.StripeId)
            .IsUnique();
        
        builder.Property(customer => customer.CreatedAt)
            .HasColumnName("created_at");
        
    }
}