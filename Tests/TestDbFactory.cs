using mongo.Entitites;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace mongo
{
    public class TestDbFactory
    {
        private static IMongoClient client;

        public static IMongoDatabase Database { get; private set; }
        public static IMongoCollection<Product> ProductCollection { get; private set; }

        static TestDbFactory()
        {
            var pack = new ConventionPack
            {
                new ElementNameConvention(),
            };
            ConventionRegistry.Register("MyConventions", pack, _ => true);

            // Edit connectionstring and dbnname here if needed
            client = new MongoClient("mongodb://localhost:27017/datadriven");
            Database = client.GetDatabase("datadriven");

            ProductCollection = Database.GetCollection<Product>("products");
        }
    }
}
