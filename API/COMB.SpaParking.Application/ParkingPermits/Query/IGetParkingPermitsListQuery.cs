using COMB.SpaParking.Application.ParkingAreas;

namespace COMB.SpaParking.Application.ParkingPermits.Query
{
    public interface IGetParkingPermitsListQuery
    {
        Task<Either<Error, IReadOnlyCollection<IParkingPermit>>> ExecuteAsync(IParkingPermitFilter request);
    }
}
