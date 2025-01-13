using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace COMB.SpaParking.Persistence.ParkingAreaTypes;

internal class ParkingAreaTypeRepository : IParkingAreaTypeRepository
{
    readonly IDatabaseService _databaseService;
    readonly ILogger<ParkingAreaTypeRepository> _logger;
    public ParkingAreaTypeRepository(IDatabaseService databaseService, ILogger<ParkingAreaTypeRepository> logger)
    {
        _logger = logger;
        _databaseService = databaseService;
    }

    public async Task<Either<Error, IReadOnlyCollection<ParkingAreaType>>> GetAsync(int skip = 0, int take = 10)
        => await _databaseService.Set<ParkingAreaType>()
            .Skip(skip)
            .Take(take).ToListAsync();

    public async Task<Either<Error, ParkingAreaType>> GetByIdAsync(int id)
    {
        var _type =await _databaseService.Set<ParkingAreaType>().FindAsync(id);
        return _type is null ? Error.Create("Parking Area Type not found") : _type;
    }
}
