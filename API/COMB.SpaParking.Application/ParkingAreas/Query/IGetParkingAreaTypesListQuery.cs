namespace COMB.SpaParking.Application.ParkingAreas.Query
{
    public interface IGetParkingAreaTypesListQuery
    {
        Task<Either<Error, IReadOnlyCollection<IParkingAreaType>>> ExecuteAsync();
    }
}
