using COMB.SpaParking.Application.Interfaces.Persistence;

namespace COMB.SpaParking.Application.ParkingAreas.Query
{
    public class GetParkingAreaTypesListQuery : IGetParkingAreaTypesListQuery
    {
        readonly IParkingAreaTypeRepository _repository;
        public GetParkingAreaTypesListQuery(IParkingAreaTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Either<Error, IReadOnlyCollection<IParkingAreaType>>> ExecuteAsync()
        {
            return (await _repository.GetAsync())
               .Map<IReadOnlyCollection<IParkingAreaType>>(areas
                       => areas.Select(e => new ParkingAreaTypeDTO(e)).ToList());
        }
    }
}
