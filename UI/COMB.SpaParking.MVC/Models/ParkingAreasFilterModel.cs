using COMB.SpaParking.Application.ParkingAreas;

namespace COMB.SpaParking.MVC.Models
{
    public class ParkingAreasFilterModel
    {
        public int Page { get; set; }
        public int Length { get; set; } = 20;
        public int ParkingAreaTypeId { get; set; }

    }

    public static class ParkingAreaFilterFactory
    {
        public static IParkingAreaFilter Create(ParkingAreasFilterModel model)
        {
            return new ParkingAreaFilterDTO
            {
                Length = model.Length,
                ParkingAreaTypeId = model.ParkingAreaTypeId,
                Skip= model.Page * model.Length
            };
        }
    }
}
