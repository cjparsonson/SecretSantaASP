using SecretSanta.EntityModels;
namespace SecretSanta.UnitTests
{
    public class EntityModelTests
    {
        [Fact]
        public void DatabaseConnectTest()
        {
            using SecretSantaContext db = new();
            Assert.True(db.Database.CanConnect());
        }
    }
}