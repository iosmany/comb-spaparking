
namespace COMB.SpaParking.Application.Interfaces.Persistence;

using COMB.SpaParking.Domain.Entities;  

public interface IParkingAreaRepository: IRepository<int, ParkingArea>
{
    Task<Either<Error, IReadOnlyCollection<ParkingArea>>> GetAsync(int skip = 0, int take = 100, int parkingAreaTypeId = 0);
}
