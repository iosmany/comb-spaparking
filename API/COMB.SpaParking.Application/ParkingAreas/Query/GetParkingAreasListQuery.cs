using COMB.SpaParking.Application.Interfaces.Persistence;

namespace COMB.SpaParking.Application.ParkingAreas.Query
{
    public class GetParkingAreasListQuery: IGetParkingAreasListQuery
    {
        readonly IParkingAreaRepository _repository;
        public GetParkingAreasListQuery(IParkingAreaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Either<Error, IReadOnlyCollection<IParkingArea>>> ExecuteAsync(IParkingAreaFilter request)
        {
            return (await _repository.GetAsync(skip: request.Skip, take: request.Length, parkingAreaTypeId: request.ParkingAreaTypeId))
                .Map<IReadOnlyCollection<IParkingArea>>(areas
                        => areas.Select(area => new ParkingAreaDTO(area)).ToList());
        }
    }
}
