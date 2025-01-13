

using System.ComponentModel.DataAnnotations;

namespace COMB.SpaParking.Application.ParkingPermits
{
    public interface IParkingPermitFilter : IFilter
    {
        string? ByLicensePlate { get; }
        bool? Expired { get; }
    }

    public class ParkingPermitFilterDTO : Filter, IParkingPermitFilter
    {
        [MaxLength(50)]
        public string? ByLicensePlate { get; set; }
        public bool? Expired { get; set; }
    }
}
