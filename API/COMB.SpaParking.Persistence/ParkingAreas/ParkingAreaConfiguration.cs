using COMB.SpaParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COMB.SpaParking.Persistence.ParkingAreas;

public class ParkingAreaConfiguration : IEntityTypeConfiguration<ParkingArea>
{
    public void Configure(EntityTypeBuilder<ParkingArea> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.ParkingAreaName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Latitude).IsRequired(false);
        builder.Property(p => p.Longitude).IsRequired(false);
        builder.Property(p => p.DateCreated).HasMaxLength(50).IsRequired();
        
        builder.HasOne(p => p.ParkingAreaType)
            .WithMany()
            .HasForeignKey("ParkingAreaTypeId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.ParkingPermits)
            .WithOne(p => p.ParkingArea)
            .HasForeignKey("ParkingAreaId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Inactive).IsRequired();

        builder.Ignore(propertyExpression: p => p.Location);
    }
}
