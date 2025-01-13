
namespace COMB.SpaParking.Domain.Entities;

using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ParkingAreas")]
public class ParkingArea : Entity
{
    //lock purposes
    private readonly object _lock = new object();

    public string? ParkingAreaName { get; private set; }
    public double? Latitude { get; private set; }
    public double? Longitude { get; private set; }
    public string? DateCreated { get; private set; }
    public virtual ParkingAreaType ParkingAreaType { get; set; }

    private List<ParkingPermit> parkingPermits = new List<ParkingPermit>();
    public virtual IReadOnlyCollection<ParkingPermit> ParkingPermits => parkingPermits;


    //ignored field [NotMapped]
    private Point? _location;
    public Point? Location
    {
        get
        {
            if (Latitude is null || Longitude is null)
                return default;

            if (_location is not null)
                return _location;

            lock (_lock)
            {
                if (_location is null) //double check
                {
                    try
                    {
                        _location = new Point(new Coordinate(Latitude.Value, Longitude.Value)); //ensure that the point is created
                    }
                    catch  // catch any exception that might occur during the creation of the point 
                    {
                    }
                }
            }
            return _location;
        }
    }

    public ParkingArea() //for migrations purposes
    {
    }

    public ParkingArea(ParkingAreaType parkingAreaType)
    {
        ParkingAreaType = parkingAreaType;
    }

    public ParkingArea(string parkingAreaName, double latitude, double longitude, ParkingAreaType parkingAreaType)
    {
        ParkingAreaName = parkingAreaName;
        Latitude = latitude;
        Longitude = longitude;
        ParkingAreaType = parkingAreaType;
    }

    public void MarkCreated()
    {
        DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

}
