using COMB.SpaParking.Application.ParkingAreas;

namespace COMB.SpaParking.Application.ParkingPermits.Command
{
    public interface IDeactivateParkingPermitCommand
    {
        public Task<Either<Error, IParkingPermit>> ExecuteAsync(int id);
    }
}
