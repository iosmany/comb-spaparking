using System.ComponentModel.DataAnnotations;
using COMB.SpaParking.Application.ParkingPermits;

namespace COMB.SpaParking.MVC.Models
{
    public class ParkingPermitsFilterModel : FilterModel
    {
        [MaxLength(15)]
        public string? ByLicensePlate { get; set; }
        public bool? Expired { get; set; }
    }

    public static class ParkingPermitFilterFactory
    {
        public static IParkingPermitFilter Create(ParkingPermitsFilterModel model)
        {
            model.Page = model.Next switch
            {
                NextPage.Next => model.Page + 1,
                NextPage.Previous => model.Page > 0? model.Page - 1 : model.Page,
                _ => model.Page
            };

            return new ParkingPermitFilterDTO
            {
                Length = model.Length,
                Skip= model.Page * model.Length,
                ByLicensePlate = model.ByLicensePlate,
                Expired = model.Expired
            };
        }
    }
}
