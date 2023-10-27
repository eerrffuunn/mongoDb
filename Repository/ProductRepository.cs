using System;
using System.Linq;
using mongo.Entitites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mongo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> productCollection;

        // Keep the constructor and the field as-is
        public ProductRepository(IMongoDatabase database)
        {
            this.productCollection = database.GetCollection<Product>("products");
        }

        public (string, double?) ProductWithLargestTotalValue(ObjectId categoryId)
        {
            var total = productCollection.Aggregate().Project(product => new
                                       {
                                           Name = product.Name,
                                           CategoryId = product.CategoryID,
                                           TotalValue = product.Stock * product.Price
                                       })
                                       .Match(product => product.CategoryId == categoryId)
                                       .SortByDescending(product => product.TotalValue)
                                       .FirstOrDefault();

            if (total == null)
            {
                return (null, null);
            }

            return (total.Name, total.TotalValue);
        }

        public double GetAllProductsCumulativeVolume()
        {
            var result = productCollection.Aggregate()
                                           .Match(product => product.Description.innerProduct.PackageParameters.PackageSize != null)
                                           .Project(product => new
                                           {
                                               Volume = product.Description.innerProduct.PackageParameters.PackageSize.Width *
                                                        product.Description.innerProduct.PackageParameters.PackageSize.Height *
                                                        product.Description.innerProduct.PackageParameters.PackageSize.Depth *
                                                        product.Description.innerProduct.PackageParameters.NumberOfPackages *
                                                        product.Stock /
                                                       (product.Description.innerProduct.PackageParameters.PackageSize.Unit.Equals("cm") ? 1000000 : 1)
                                           })
                                           .ToList()?
                                           .Sum(product => product.Volume);

            return Math.Round(result.Value, 7);
        }
    }
}
