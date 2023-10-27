using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace mongo.Tests
{
    [TestClass]
    public class TestExercise1
    {
        [TestMethod]
        public void Ex1_ValidCategory()
        {
            var repo = new ProductRepository(TestDbFactory.Database);
            var categoryId = ObjectId.Parse("5d7e4370cffa8e1030fd2da0");

            (var productName, var totalValue) = repo.ProductWithLargestTotalValue(categoryId);

            Assert.AreEqual("Activity playgim", productName);
            Assert.AreEqual(157248.0, totalValue);
        }

        [TestMethod]
        public void Ex1_NoProduct()
        {
            var repo = new ProductRepository(TestDbFactory.Database);
            var categoryId = ObjectId.Parse("5d7e42adcffa8e1b64f7dbbb");

            (var productName, var totalValue) = repo.ProductWithLargestTotalValue(categoryId);

            Assert.IsNull(productName);
            Assert.IsNull(totalValue);
        }
    }
}
