using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mongo.Tests
{
    [TestClass]
    public class TestExercise2
    {
        [TestMethod]
        public void Ex2_ProductsCumulativeVolume()
        {
            var repo = new ProductRepository(TestDbFactory.Database);

            var totalVolume = repo.GetAllProductsCumulativeVolume();

            Assert.AreEqual(2.9541, totalVolume);
        }
    }
}
