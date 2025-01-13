
namespace COMB.SpaParking.Specification.ParkingAreas
{
    [TestFixture]
    public class ParkingAreaTests
    {

        [SetUp]
        public void Setup()
        {
            Persistence.Configuration.Properties.SqlEngine = Persistence.Configuration.SqlEngine.InMemory;
        }

        [Test]
        public async Task AsCustomerServiceRepListParkingAreasByParkingType()
        {
            
        }
    }
}
