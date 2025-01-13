using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace COMB.SpaParking.Persistence.ParkingAreas;

sealed class ParkingAreaRepository : IParkingAreaRepository
{
    readonly IDatabaseService _databaseService;
    readonly ILogger<ParkingAreaRepository> _logger;

    public ParkingAreaRepository(IDatabaseService databaseService, ILogger<ParkingAreaRepository> logger)
    {
        _databaseService = databaseService;
        _logger = logger;
    }

    IQueryable<ParkingArea> Query()
       => _databaseService.Set<ParkingArea>()
                .Include(p => p.ParkingAreaType)
                .AsNoTracking()
                .OrderByDescending(p => p.Id);

    public async Task<Either<Error, IReadOnlyCollection<ParkingArea>>> GetAsync(int skip = 0, int take = 100)
    {
        var entities = await Query()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        return entities;
    }

    public async Task<Either<Error, IReadOnlyCollection<ParkingArea>>> GetAsync(int skip = 0, int take = 100, int parkingTypeId=0)
    {
        var query = Query();
        query = parkingTypeId > 0 ? query.Where(x => x.ParkingAreaType.Id == parkingTypeId) : query;
        var entities = await query 
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        return entities;
    }

    public async Task<Either<Error, ParkingArea>> GetByIdAsync(int id)
    {
        var entity= await _databaseService.Set<ParkingArea>().FindAsync(id);
        if (entity is null)
            return Error.Create("Parking Area not found");
        return entity;
    }
}
