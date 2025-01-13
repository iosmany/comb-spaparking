using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Application.ParkingAreas;
using Microsoft.Extensions.Logging;

namespace COMB.SpaParking.Application.ParkingPermits.Query
{
    public class GetParkingPermitDetailQuery : IGetParkingPermitDetailQuery
    {
        readonly IParkingPermitRepository _repository;
        readonly ILogger<GetParkingPermitDetailQuery> _logger;
        public GetParkingPermitDetailQuery(IParkingPermitRepository repository, ILogger<GetParkingPermitDetailQuery> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Either<Error, IParkingPermit>> ExecuteAsync(int parkingPermitId)
        {
            return (await _repository.GetByIdAsync(parkingPermitId))
                .Map<IParkingPermit>(permit => new ParkingPermitDTO(permit));
        }
    }
}
