
using System.ComponentModel.DataAnnotations.Schema;

namespace COMB.SpaParking.Domain.Entities;

[Table("ParkingAreaTypes")]
public class ParkingAreaType : Entity
{
    public ParkingAreaType()
    {
    }

    public ParkingAreaType(string parkingAreaTypeDescription)
    {
        ParkingAreaTypeDescription = parkingAreaTypeDescription;
    }
    public string ParkingAreaTypeDescription { get; private set; }
}
