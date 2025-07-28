using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarMarketPlace.Infrastructure.Persistance.Configurations;

public class CarConfigurtaion : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Brand).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Model).HasMaxLength(100).IsRequired(true);
        builder.Property(x => x.Year).IsRequired(true);
        builder.Property(x => x.Price).IsRequired(true);
        builder.Property(x => x.Mileage).IsRequired(true);
        builder.Property(x => x.Color).HasMaxLength(50).IsRequired(true);
        builder.Property(x => x.FuelType).HasMaxLength(50).IsRequired(true);
        builder.Property(x => x.Transmission).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.Description).HasMaxLength(600).IsRequired(true);
        builder.Property(x => x.IsAvailable).HasDefaultValue(false).IsRequired(true);

        builder.HasOne(p => p.CarBrand)
                .WithMany(u => u.Cars)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(p => p.Dealer)
            .WithMany(u => u.Cars)
            .HasForeignKey(p => p.DealerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
