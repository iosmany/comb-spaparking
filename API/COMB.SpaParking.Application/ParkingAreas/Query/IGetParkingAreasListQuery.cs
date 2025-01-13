namespace COMB.SpaParking.Application.ParkingAreas.Query
{
    public interface IGetParkingAreasListQuery
    {
        Task<Either<Error, IReadOnlyCollection<IParkingArea>>> ExecuteAsync(IParkingAreaFilter request);
    }
}
