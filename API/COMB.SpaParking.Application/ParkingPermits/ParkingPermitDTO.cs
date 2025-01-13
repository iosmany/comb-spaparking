namespace COMB.SpaParking.Application.ParkingAreas
{
    public interface IParkingPermit
    {
        int Id { get;  }
        string? LicensePlate { get; }
        DateTimeOffset EffectiveDate { get; }
        DateTimeOffset ExpirationDate { get; }
        int ParkingAreaId { get; }
        string? ParkingAreaName { get; }
        DateTimeOffset DateCreated { get; }
        bool Inactive { get; }
    }

    public class ParkingPermitDTO : IParkingPermit
    {
        public int Id { get; set; }
        public string? LicensePlate { get; set; }
        public DateTimeOffset EffectiveDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public int ParkingAreaId { get; set; }
        public string? ParkingAreaName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool Inactive { get; set; }

        public ParkingPermitDTO()
        {
        }

        internal ParkingPermitDTO(Domain.Entities.ParkingPermit entity)
        {
            Id= entity.Id;
            LicensePlate = entity.LicensePlate;
            EffectiveDate = entity.EffectiveDate;
            ExpirationDate = entity.ExpirationDate;
            ParkingAreaId = entity.ParkingArea.Id;
            ParkingAreaName = entity.ParkingArea.ParkingAreaName;
            DateCreated = entity.DateCreated;
            Inactive = entity.Inactive;
        }
    }
}
