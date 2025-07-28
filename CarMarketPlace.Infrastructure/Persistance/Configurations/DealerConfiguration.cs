using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarMarketPlace.Infrastructure.Persistance.Configurations;

public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
{
    public void Configure(EntityTypeBuilder<Dealer> builder)
    {
        builder.ToTable("Dealers");

        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Name).HasMaxLength(100).IsRequired(true);
        builder.Property(x=>x.Address).HasMaxLength(100).IsRequired(true);
        builder.Property(x=>x.Phone).HasMaxLength(100).IsRequired(true);
        builder.HasIndex(x => x.Phone).IsUnique(true);
        builder.Property(x=>x.Email).HasMaxLength(100).IsRequired(true);
        builder.HasIndex(x => x.Email).IsUnique(true);
        builder.Property(x => x.Rating).HasDefaultValue(5.0).IsRequired(true);
        builder.HasOne(p => p.City)
                .WithMany(u => u.Dealers)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
