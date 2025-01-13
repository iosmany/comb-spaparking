using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Application.ParkingAreas;
using COMB.SpaParking.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace COMB.SpaParking.Application.ParkingPermits.Command
{
    public sealed class DeactivateParkingPermitCommand : IDeactivateParkingPermitCommand
    {
        readonly IParkingPermitRepository _repository;
        readonly ILogger<DeactivateParkingPermitCommand> _logger;
        public DeactivateParkingPermitCommand(IParkingPermitRepository repository, ILogger<DeactivateParkingPermitCommand> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Either<Error, IParkingPermit>> ExecuteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            entity= entity.Bind<ParkingPermit>(ent =>
            {
                if (ent.ExpirationDate > DateTime.Now)
                    return Error.Create("Parking Permit is not expired yet");
                return ent;
            });
            var response= await entity.BindAsync(_repository.DeActivateAsync);
            return response.Map<IParkingPermit>(ent => new ParkingPermitDTO(ent));
        }
    }
}
