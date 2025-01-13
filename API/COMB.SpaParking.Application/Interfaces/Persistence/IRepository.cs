namespace COMB.SpaParking.Application.Interfaces.Persistence
{
    public interface IRepository<K,E>
    {
        /// <summary>
        /// Get entity by id of type E by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Either<Error, E>> GetByIdAsync(K id);
        /// <summary>
        /// Get all entities of type E
        /// </summary>
        /// <returns></returns>
        Task<Either<Error, IReadOnlyCollection<E>>> GetAsync(int skip=0, int take= 100);
    }
}
