
using Microsoft.EntityFrameworkCore;

namespace COMB.SpaParking.Application.Interfaces.Persistence;

/// <summary>
/// Interface that wrap the database context and allows the use of custom methods
/// in order to avoid the use of the context directly in the services
/// </summary>
public interface IDatabaseService : IDisposable, IAsyncDisposable
{
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
