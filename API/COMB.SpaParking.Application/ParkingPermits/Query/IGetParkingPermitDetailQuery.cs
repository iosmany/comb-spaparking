using COMB.SpaParking.Application.ParkingAreas;

namespace COMB.SpaParking.Application.ParkingPermits.Query
{
    public interface IGetParkingPermitDetailQuery
    {
        Task<Either<Error, IParkingPermit>> ExecuteAsync(int parkingPermitId);
    }
}
