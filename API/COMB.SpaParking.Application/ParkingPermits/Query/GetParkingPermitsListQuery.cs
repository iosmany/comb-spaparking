using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Application.ParkingAreas;
using Microsoft.Extensions.Logging;

namespace COMB.SpaParking.Application.ParkingPermits.Query
{
    public class GetParkingPermitsListQuery: IGetParkingPermitsListQuery
    {
        readonly IParkingPermitRepository _repository;
        readonly ILogger<GetParkingPermitsListQuery> _logger;
        public GetParkingPermitsListQuery(IParkingPermitRepository repository, ILogger<GetParkingPermitsListQuery> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Either<Error, IReadOnlyCollection<IParkingPermit>>> ExecuteAsync(IParkingPermitFilter request)
        {
            return (await _repository.GetAsync(skip: request.Skip, take: request.Length, licensePlate: request.ByLicensePlate, expired: request.Expired))
                .Map<IReadOnlyCollection<IParkingPermit>>(permits => permits.Select(p => new ParkingPermitDTO(p)).ToList());
        }
    }
}
