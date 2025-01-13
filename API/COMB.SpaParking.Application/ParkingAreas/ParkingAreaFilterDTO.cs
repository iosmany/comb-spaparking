

namespace COMB.SpaParking.Application.ParkingAreas
{
    public interface IParkingAreaFilter : IFilter
    { 
        int ParkingAreaTypeId { get; }
    }

    public class ParkingAreaFilterDTO : Filter, IParkingAreaFilter
    {
        public int ParkingAreaTypeId { get; set; }
    }
}
