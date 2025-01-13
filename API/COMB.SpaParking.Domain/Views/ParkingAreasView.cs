

namespace COMB.SpaParking.Domain.Views;
public class ParkingAreasView
{
    public int ParkingAreaID { get; set; }
    public required string ParkingAreaName { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public required string AreaDescription { get; set; }
}

/*
  dbo.ParkingAreas.Id AS ParkingAreaID,
dbo.ParkingAreas.ParkingAreaName, 
dbo.ParkingAreas.Latitude, 
dbo.ParkingAreas.Longitude, 
dbo.ParkingAreaTypes.ParkingAreaTypeDescription AS AreaDescription
 */
