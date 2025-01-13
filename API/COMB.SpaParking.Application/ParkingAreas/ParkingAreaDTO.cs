namespace COMB.SpaParking.Application.ParkingAreas
{
    public interface IParkingArea
    {
        int Id { get; }
        string? ParkingAreaName { get; }
        double? Latitude { get; }
        double? Longitude { get; }
        string? DateCreated { get;  }
        int ParkingAreaTypeId { get; }
        string? ParkingAreaTypeDescription { get; }
    }

    public class ParkingAreaDTO : IParkingArea
    {
        public int Id { get; set; }
        public string? ParkingAreaName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? DateCreated { get; set; }
        public int ParkingAreaTypeId { get; set; }
        public string? ParkingAreaTypeDescription { get; set; }


        public ParkingAreaDTO()
        {
        }

        internal ParkingAreaDTO(Domain.Entities.ParkingArea entity)
        {
            Id= entity.Id;
            ParkingAreaName = entity.ParkingAreaName;
            Latitude = entity.Latitude;
            Longitude = entity.Longitude;
            DateCreated = entity.DateCreated;
            ParkingAreaTypeId = entity.ParkingAreaType.Id;
            ParkingAreaTypeDescription = entity.ParkingAreaType.ParkingAreaTypeDescription;
        }
    }
}
