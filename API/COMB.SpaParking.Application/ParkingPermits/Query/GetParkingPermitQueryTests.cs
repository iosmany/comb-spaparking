

using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Application.ParkingAreas;
using COMB.SpaParking.Domain.Entities;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace COMB.SpaParking.Application.ParkingPermits.Query;

[TestFixture]
public class GetParkingPermitQueryTests
{
    private AutoMocker _autoMocker;
    private GetParkingPermitsListQuery _getParkingPermitsListQuery;
    private GetParkingPermitDetailQuery _getParkingPermitDetailQuery;


    readonly static ParkingAreaType parkingAreaType = new ParkingAreaType("Public");
    readonly static ParkingArea parkingArea = new ParkingArea("Flamingo", 0, 0, parkingAreaType);

    readonly static DateTime now = DateTime.Now;

    readonly List<ParkingPermit> source = new()
    {
        new ParkingPermit("ABD789", now.AddDays(-1), now.AddDays(10), parkingArea),
        new ParkingPermit("ABD445", now.AddDays(-3), now.AddDays(8), parkingArea),
        new ParkingPermit("ABD211", now.AddDays(-10), now.AddDays(-1), parkingArea),
    };

    [OneTimeSetUp]
    public void Setup()
    {
        _autoMocker = new AutoMocker();

        Func<int,int,string?, bool?, Task<Either<Error, IReadOnlyCollection<ParkingPermit>>>> getAsync = (int skip, int length, string? licensePlate, bool? expired) =>
        {
            var query = source.AsQueryable();

            if (!string.IsNullOrWhiteSpace(licensePlate))
                query = query.Where(x => x.LicensePlate != null && x.LicensePlate.Contains(licensePlate));
            if (expired is not null)
                query = expired.Value ? query.Where(x => x.ExpirationDate < DateTime.Now) : query.Where(x => x.ExpirationDate > DateTime.Now);

            var result = source
                .Skip(skip)
                .Take(length).ToList();

            return Task.FromResult(Either<Error, IReadOnlyCollection<ParkingPermit>>.Right(result));
        };

        var moq = _autoMocker.GetMock<IParkingPermitRepository>();
        moq
            .Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<bool?>()))
            .Returns(getAsync);
        moq
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => Task.FromResult(Either<Error, ParkingPermit>.Right(source.First())));

        _getParkingPermitsListQuery = _autoMocker.CreateInstance<GetParkingPermitsListQuery>();
        _getParkingPermitDetailQuery = _autoMocker.CreateInstance<GetParkingPermitDetailQuery>();
    }

    [Test]
    public async Task Should_Get_ParkingAreaList()
    {
        var response= await _getParkingPermitsListQuery.ExecuteAsync(new ParkingPermitFilterDTO() { Skip = 0, Length = 10 });
        Assert.That(response.IsRight);
        response.Bind<IReadOnlyCollection<IParkingPermit>>(result =>
        {
            Assert.That(result.Count, Is.GreaterThan(0));
            return result.ToList();
        });
    }

    [Test]
    public async Task Should_Return_ParkingPermitDetail()
    {
        var response= await _getParkingPermitDetailQuery.ExecuteAsync(1);
        Assert.That(response.IsRight);
        response.Bind<IParkingPermit>(result =>
        {
            Assert.That(result, Is.Not.Null);   
            return Right(result);
        });
    }

    [Test]
    public async Task Should_Return_ExpiredParkingPaermits()
    {
        var response = await _getParkingPermitsListQuery.ExecuteAsync(new ParkingPermitFilterDTO() { Skip = 0, Length = 10, Expired = true });
        Assert.That(response.IsRight);
        response.Bind<IReadOnlyCollection<IParkingPermit>>(result =>
        {
            Assert.That(result.Count, Is.GreaterThan(0));
            return result.ToList();
        });
    }


}

