using COMB.SpaParking.Domain.Entities;

namespace COMB.SpaParking.Application.ParkingAreas;

public interface IParkingAreaType
{
    int Id { get; }
    string ParkingAreaTypeDescription { get; }
    bool Inactive { get; }
}

public class ParkingAreaTypeDTO : IParkingAreaType
{
    public int Id { get; set; }
    public string ParkingAreaTypeDescription { get; set; }
    public bool Inactive { get; set; }

    public ParkingAreaTypeDTO()
    {
        ParkingAreaTypeDescription = string.Empty;
    }
    public ParkingAreaTypeDTO(ParkingAreaType entity) : this()
    {
        Id = entity.Id;
        ParkingAreaTypeDescription = entity.ParkingAreaTypeDescription;
        Inactive = entity.Inactive;
    }
}
