using COMB.SpaParking.Domain.Entities;

namespace COMB.SpaParking.Application.Interfaces.Persistence;

public interface IParkingPermitRepository: IRepository<int, ParkingPermit>
{
    Task<Either<Error, ParkingPermit>> DeActivateAsync(ParkingPermit parkingPermit);
    Task<Either<Error, IReadOnlyCollection<ParkingPermit>>> GetAsync(int skip = 0, int take = 100, string? licensePlate = null, bool? expired = null);
}
