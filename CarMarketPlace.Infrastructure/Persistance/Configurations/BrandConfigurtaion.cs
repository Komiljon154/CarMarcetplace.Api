using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarMarketPlace.Infrastructure.Persistance.Configurations;

public class BrandConfigurtaion : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Country).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Description).HasMaxLength(600).IsRequired(false);
    }
}
