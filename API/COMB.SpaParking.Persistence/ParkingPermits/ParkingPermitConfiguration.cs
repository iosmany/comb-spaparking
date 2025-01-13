using COMB.SpaParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace COMB.SpaParking.Persistence.ParkingPermits;

public class ParkingPermitConfiguration : IEntityTypeConfiguration<ParkingPermit>
{
    public void Configure(EntityTypeBuilder<ParkingPermit> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.LicensePlate).HasMaxLength(50).IsRequired();
        builder.Property(p => p.EffectiveDate).IsRequired();
        builder.Property(p => p.ExpirationDate).IsRequired();
        builder.Property(p => p.DateCreated).IsRequired();

        builder.HasOne(p => p.ParkingArea)
            .WithMany(p=>p.ParkingPermits)
            .HasForeignKey("ParkingAreaId").OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Inactive).IsRequired();

        //indexes
        builder.HasIndex(p=> p.LicensePlate).IsUnique();
    }
}
