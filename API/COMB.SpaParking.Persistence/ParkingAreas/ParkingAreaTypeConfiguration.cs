using COMB.SpaParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMB.SpaParking.Persistence.ParkingAreas;

public class ParkingAreaTypeConfiguration : IEntityTypeConfiguration<ParkingAreaType>
{
    public void Configure(EntityTypeBuilder<ParkingAreaType> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Inactive).IsRequired();
        builder.Property(p => p.ParkingAreaTypeDescription)
            .HasMaxLength(50)
            .IsRequired();
    }
}
