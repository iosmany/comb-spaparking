using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain.Entities;
using COMB.SpaParking.Persistence.ParkingAreas;
using Microsoft.Extensions.Logging;
using Moq.AutoMock;
using NUnit.Framework;

namespace COMB.SpaParking.Persistence.ParkingPermits
{
    [TestFixture]
    public class ParkingPermitRepositoryTests
    {
        private AutoMocker _autoMocker; 
        private IDatabaseService _databaseService;

        private ILogger<ParkingPermitRepository> _logger;

        private ParkingPermit customParkingPermit;

        private IParkingPermitRepository _repository;

        [OneTimeSetUp]
        public void Setup()
        {
            _autoMocker = new AutoMocker();

            Configuration.Properties.SqlEngine = Configuration.SqlEngine.InMemory;
            _databaseService = new DatabaseContext();
            
            var loggerFactory = _autoMocker.Get<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger<ParkingPermitRepository>();

            var parkingAreaType = new ParkingAreaType("Residential");
            _databaseService.Set<ParkingAreaType>().Add(parkingAreaType);
            var parkingArea = new ParkingArea("Boulevar", 0, 0, parkingAreaType);
            _databaseService.Set<ParkingArea>().Add(parkingArea);

            var now = DateTime.Now;
            customParkingPermit = new ParkingPermit("ABC123", now.AddDays(-5), now.AddDays(10), parkingArea);
            _databaseService.Set<ParkingPermit>().Add(customParkingPermit);
            _databaseService.Set<ParkingPermit>().Add(new ParkingPermit("ABC456", now.AddDays(-1), now.AddDays(20), parkingArea));
            _databaseService.Set<ParkingPermit>().Add(new ParkingPermit("ABC789", now.AddDays(-30), now.AddDays(-5), parkingArea));
            _databaseService.Set<ParkingPermit>().Add(new ParkingPermit("ABC102", now.AddDays(-13), now.AddDays(-1), parkingArea));
            _databaseService.Set<ParkingPermit>().Add(new ParkingPermit("ABC222", now.AddDays(-7), now.AddDays(2), parkingArea));

            _databaseService.SaveChangesAsync().Wait();

            _repository = new ParkingPermitRepository(_databaseService, _logger);
        }

        [Test]
        public async Task GetParkingPermitById_WhenCalled_ReturnsParkingPermit()
        {
            var result = await _repository.GetByIdAsync(customParkingPermit.Id);
            Assert.That(result.IsRight);

            result.Bind<ParkingPermit>(entity =>
            {
                Assert.That(entity.Id, Is.EqualTo(customParkingPermit.Id));
                Assert.That(entity.EffectiveDate, Is.EqualTo(customParkingPermit.EffectiveDate));
                Assert.That(entity.LicensePlate, Is.EqualTo(customParkingPermit.LicensePlate));
                Assert.Pass($"Getting Parking Permit [{customParkingPermit.Id}] executed successfully");
                return entity;
            });
        }

        [Test]
        public async Task GetParkingPermits_FilteredBy_CustomSkipLength()
        {
            var result = await _repository.GetAsync(1,3);
            Assert.That(result.IsRight);
            result.Bind<IReadOnlyCollection<ParkingPermit>>(res =>
            {
                Assert.That(res.Count, Is.GreaterThan(0));
                Assert.That(res.Count==3);
                Assert.Pass($"Getting Parking Permits filtering using skip and length executed successfully");
                return res.ToList();
            });
        }

        [Test]
        public async Task GetParkingPermits_FilteredBy_ContainsLicensePlate()
        {
            var result = await _repository.GetAsync(licensePlate: "C1");
            Assert.That(result.IsRight);

            result.Bind<IReadOnlyCollection<ParkingPermit>>(res =>
            {
                Assert.That(res.Count, Is.EqualTo(2));
                Assert.That(res.FirstOrDefault(x=>x.LicensePlate == "ABC123"), Is.Not.Null);
                Assert.That(res.FirstOrDefault(x=>x.LicensePlate == "ABC102"), Is.Not.Null);
                Assert.Pass($"Getting Parking Permits filtering by licenseplate executed successfully");
                return res.ToList();
            });

        }

        [Test]
        public async Task Should_Returns_ExpiredParkingPermits()
        {
            var result = await _repository.GetAsync(expired: true);
            Assert.That(result.IsRight);

            result.Bind<IReadOnlyCollection<ParkingPermit>>(res =>
            {
                Assert.That(res.Count, Is.EqualTo(2));
                Assert.That(res.FirstOrDefault(x => x.LicensePlate == "ABC789"), Is.Not.Null);
                Assert.That(res.FirstOrDefault(x => x.LicensePlate == "ABC102"), Is.Not.Null);
                return res.ToList();
            });
        }

        [Test]
        public async Task Should_Returns_ActiveParkingPermits()
        {
            var result = await _repository.GetAsync(expired: false);
            Assert.That(result.IsRight);

            result.Bind<IReadOnlyCollection<ParkingPermit>>(res =>
            {
                Assert.That(res.Count, Is.EqualTo(3));
                Assert.That(res.FirstOrDefault(x => x.LicensePlate == "ABC123"), Is.Not.Null);
                Assert.That(res.FirstOrDefault(x => x.LicensePlate == "ABC456"), Is.Not.Null);
                Assert.That(res.FirstOrDefault(x => x.LicensePlate == "ABC222"), Is.Not.Null);
                return res.ToList();
            });
        }

        [Test]
        public async Task Should_DeActive_ExpiredPermits()
        {
            var expiredPermits= await _repository.GetAsync(expired: true);
            Assert.That(expiredPermits.IsRight);

            ParkingPermit? parkingPermit = null;
            await expiredPermits.BindAsync(async exp =>
            {
                parkingPermit = exp.FirstOrDefault();
                Assert.That(parkingPermit, Is.Not.Null);
                var result = await _repository.DeActivateAsync(parkingPermit!);
                Assert.That(result.IsRight);
                result.Bind<ParkingPermit>(permit =>
                {
                    Assert.That(permit.Inactive, Is.True);
                    Assert.Pass($"Parking Permit de-activated successfully");
                    return permit;
                });
                return result;
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _databaseService.Dispose();
        }
    }
}
