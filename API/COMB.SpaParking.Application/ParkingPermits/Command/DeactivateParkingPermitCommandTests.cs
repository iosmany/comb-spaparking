using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace COMB.SpaParking.Application.ParkingPermits.Command
{
    [TestFixture]
    public class DeactivateParkingPermitCommandTests
    {
        private AutoMocker _autoMocker;

        private IDeactivateParkingPermitCommand _deactivateParkingPermit;

        private IParkingPermitRepository _repository;

        readonly static ParkingAreaType parkingAreaType = new("Public");
        readonly static ParkingArea parkingArea = new("Kendall", 0, 0, parkingAreaType);

        readonly List<ParkingPermit> source = new()
        {
            new ParkingPermit("ABD789", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-5), parkingArea),
        };

        [SetUp]
        public void Setup()
        {
            _autoMocker = new AutoMocker();
            
            var repositoryMock = _autoMocker.GetMock<IParkingPermitRepository>();
            repositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns((int id) => Task.FromResult(Either<Error, ParkingPermit>.Right(source.First())));

            repositoryMock
                .Setup(x => x.DeActivateAsync(It.IsAny<ParkingPermit>()))
                .Returns((ParkingPermit permit) => 
                {
                    permit.SetInactive(true);
                    return Task.FromResult(Either<Error, ParkingPermit>.Right(permit));
                });

            _repository = _autoMocker.Get<IParkingPermitRepository>();

            var loggerFactory = _autoMocker.Get<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<DeactivateParkingPermitCommand>();

            _deactivateParkingPermit = new DeactivateParkingPermitCommand(_repository, logger);
        }

        [Test]
        public async Task Should_ReturnsParkingPermit_Inactive()
        {
            var permit = source.First();
            Assert.That(permit, Is.Not.Null);
            Assert.That(!permit.Inactive);
            Assert.That(permit.ExpirationDate < DateTime.Now);

            var response = await _deactivateParkingPermit.ExecuteAsync(1);
            Assert.That(response.IsRight, Is.True);

            response.Do(ent =>
            {
                Assert.That(ent, Is.Not.Null);
                Assert.That(ent.Inactive, Is.True);
            });
        }
    }
}
