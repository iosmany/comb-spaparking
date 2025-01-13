

using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain.Entities;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace COMB.SpaParking.Application.ParkingAreas.Query;

[TestFixture]
public class GetParkingAreasListQueryTests
{

    private AutoMocker _autoMocker;
    private GetParkingAreasListQuery _getParkingAreasListQuery;

    readonly static ParkingAreaType parkingAreaType = new ParkingAreaType("Public");

    readonly List<ParkingArea> source = new()
    {
        new ParkingArea("Flamingo", 0, 0, parkingAreaType),
        new ParkingArea("Belle Isle",0, 0, parkingAreaType),
        new ParkingArea("Art Deco" ,0, 0, parkingAreaType),
        new ParkingArea("South Point" ,0, 0, parkingAreaType),
    };

    [SetUp]
    public void Setup()
    {
        _autoMocker = new AutoMocker();

        Func<int,int,int, Task<Either<Error, IReadOnlyCollection<ParkingArea>>>> getAsync = (int skip, int length, int parkingTypeId) =>
        {
            var result = source
                .Skip(skip)
                .Take(length).ToList();

            return Task.FromResult(Either<Error, IReadOnlyCollection<ParkingArea>>.Right(result));
        };

        var moq = _autoMocker.GetMock<IParkingAreaRepository>();
        moq
            .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .Returns(getAsync);
        moq
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => Task.FromResult(Either<Error, ParkingArea>.Right(source.First(x => x.Id == id))));

        _getParkingAreasListQuery = _autoMocker.CreateInstance<GetParkingAreasListQuery>();
    }

    [Test]
    public async Task Should_Get_ParkingAreaList()
    {
        var response= await _getParkingAreasListQuery.ExecuteAsync(new ParkingAreaFilterDTO() { Skip = 0, Length = 10 });
        Assert.That(response.IsRight);

        response.Bind<IReadOnlyCollection<IParkingArea>>(result =>
        {
            Assert.That(result.Count, Is.GreaterThan(0));
            return result.ToList();
        });

    }
}

