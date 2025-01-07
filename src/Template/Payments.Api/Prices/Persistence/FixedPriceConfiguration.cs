using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payments.Api.Prices.Persistence;

internal sealed class FixedPriceConfiguration : IEntityTypeConfiguration<FixedPrice>
{
    public void Configure(EntityTypeBuilder<FixedPrice> builder)
    {
        builder.ToTable("fixed_prices");
    }
}