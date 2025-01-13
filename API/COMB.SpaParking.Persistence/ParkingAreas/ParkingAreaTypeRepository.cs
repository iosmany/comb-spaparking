using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace COMB.SpaParking.Persistence.ParkingAreas;

sealed class ParkingAreaTypeRepository : IParkingAreaTypeRepository
{
    readonly IDatabaseService _databaseService;
    readonly ILogger<ParkingAreaTypeRepository> _logger;

    public ParkingAreaTypeRepository(IDatabaseService databaseService, ILogger<ParkingAreaTypeRepository> logger)
    {
        _databaseService = databaseService;
        _logger = logger;
    }

    public async Task<Either<Error, IReadOnlyCollection<ParkingAreaType>>> GetAsync(int skip = 0, int take = 100)
    {
        var entities = await _databaseService.Set<ParkingAreaType>()
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();

        return entities;
    }

    public async Task<Either<Error, ParkingAreaType>> GetByIdAsync(int id)
    {
        var entity= await _databaseService.Set<ParkingAreaType>().FindAsync(id);
        if (entity is null)
            return Error.Create("Parking Area Type not found");
        return entity;
    }
}
