using System.ComponentModel.DataAnnotations.Schema;

namespace COMB.SpaParking.Domain.Entities;

[Table("ParkingPermits")]
public class ParkingPermit : Entity, IAudit
{
    public string? LicensePlate { get; private set; }
    public DateTime EffectiveDate { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public virtual ParkingArea ParkingArea { get; private set; }
    public DateTime DateCreated { get; private set; }

    public ParkingPermit()
    {
        
    }
    public ParkingPermit(ParkingArea parkingArea)
    {
        ParkingArea = parkingArea;
    }

    public ParkingPermit(string licensePlate, DateTime effectiveDate, DateTime expirationDate, ParkingArea parkingArea)
        : this(parkingArea)
    {
        LicensePlate = licensePlate;
        EffectiveDate = effectiveDate;
        ExpirationDate = expirationDate;
    }

    public void MarkCreated()
    {
        DateCreated = DateTime.Now;
    }

    public void SetInactive(bool isInactive)
    {
        Inactive = isInactive;
    }
}
