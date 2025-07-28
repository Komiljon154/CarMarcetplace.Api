using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarMarketPlace.Infrastructure.Persistance.Configurations;

public class CityConfigurtaion : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Citys");

        builder.HasKey(x=>x.Id);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Region).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Country).HasMaxLength(100).IsRequired(true);
    }
}
