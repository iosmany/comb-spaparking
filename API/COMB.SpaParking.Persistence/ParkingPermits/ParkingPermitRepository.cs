using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace COMB.SpaParking.Persistence.ParkingAreas;

sealed class ParkingPermitRepository : IParkingPermitRepository
{
    readonly IDatabaseService _databaseService;
    readonly ILogger<ParkingPermitRepository> _logger;

    public ParkingPermitRepository(IDatabaseService databaseService, ILogger<ParkingPermitRepository> logger)
    {
        _databaseService = databaseService;
        _logger = logger;
    }

    IQueryable<ParkingPermit> Query()
        => _databaseService.Set<ParkingPermit>()
            .OrderByDescending(p => p.Id);  

    async Task<List<ParkingPermit>> Complete(IQueryable<ParkingPermit> query, int skip = 0, int take = 100)
    {
        return await query.Skip(skip)
                .Take(take)
                .ToListAsync();
    }
    
    public async Task<Either<Error, IReadOnlyCollection<ParkingPermit>>> GetAsync(int skip = 0, int take = 100)
        => await Complete(Query(), skip, take);   

    public async Task<Either<Error, IReadOnlyCollection<ParkingPermit>>> GetAsync(int skip = 0, int take = 100, string? licensePlate = null, bool? expired=null)
    {
        var query = Query();
        if (!string.IsNullOrWhiteSpace(licensePlate))
            query = query.Where(x => x.LicensePlate != null && x.LicensePlate.Contains(licensePlate));
        if(expired is not null)
            query = expired.Value ? query.Where(x => x.ExpirationDate < DateTime.Now) : query.Where(x => x.ExpirationDate > DateTime.Now);

        return await Complete(query, skip, take);
    }

    public async Task<Either<Error, ParkingPermit>> GetByIdAsync(int id)
    {
        var entity = await _databaseService.Set<ParkingPermit>().FindAsync(id);
        if (entity is null)
            return Error.Create("Parking Area not found");
        return entity;
    }

    public async Task<Either<Error, ParkingPermit>> DeActivateAsync(ParkingPermit parkingPermit)
    {
        if (parkingPermit.Inactive)
            return Error.Create("Parking Permit is already inactive");

        try
        {
            parkingPermit.SetInactive(true);
            await _databaseService.SaveChangesAsync();
            return parkingPermit;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deactivating parking permit");
            return Error.Create("Error deactivating parking permit");
        }
    }
}
