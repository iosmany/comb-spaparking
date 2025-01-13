
namespace COMB.SpaParking.Domain.Views;
public class ParkingsPermitsByAreaView
{
    public int PermitID { get; set; }
    public required string LicensePlate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public required string ParkingAreaName { get; set; }
}
