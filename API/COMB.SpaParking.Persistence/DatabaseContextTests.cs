using NUnit.Framework;

namespace COMB.SpaParking.Persistence
{
    [TestFixture]
    public class DatabaseContextTests
    {
        [SetUp]
        public void Setup()
        {
            Configuration.Properties.SqlEngine = Configuration.SqlEngine.InMemory;
        }

        [Test]
        public void Should_Instantiate_DatabaseContext()
        {
            Assert.That(Configuration.Properties.SqlEngine == Configuration.SqlEngine.InMemory);
            using var context = new DatabaseContext();
            Assert.That(context, Is.Not.Null);
        }

        [Test]
        public void Should_Renamed_AspNetEntities()
        {
            Assert.That(Configuration.Properties.SqlEngine == Configuration.SqlEngine.InMemory);
            using var context = new DatabaseContext();
            var model = context.Model;
            Assert.That(model.FindEntityType("AspNetUsers"), Is.Null);
            Assert.That(model.FindEntityType("AspNetRoles"), Is.Null);
            Assert.That(model.FindEntityType("AspNetUserRoles"), Is.Null);
            Assert.That(model.FindEntityType("AspNetUserClaims"), Is.Null);
            Assert.That(model.FindEntityType("AspNetUserLogins"), Is.Null);
            Assert.That(model.FindEntityType("AspNetUserTokens"), Is.Null);
        }
    }
}
