using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongo.Entitites
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        public ObjectId ID { get; set; }
        public ObjectId CategoryID { get; set; }

        public string Name { get; set; }
        public double? Price { get; set; }

        [BsonElement("stock")]
        public int? Stock { get; set; }


        [BsonElement("description")]
        public Description Description { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class Description
    {
        [BsonElement("product")]
        public innerProduct innerProduct { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class innerProduct
    {
        [BsonElement("package_parameters")]
        public PackageParameters PackageParameters { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class PackageParameters
    {
        [BsonElement("number_of_packages")]
        public int? NumberOfPackages { get; set; }


        [BsonElement("package_size")]
        public PackageSize PackageSize { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class PackageSize
    {
        [BsonElement("unit")]
        public string Unit { get; set; }

        [BsonElement("width")]
        public double? Width { get; set; }

        [BsonElement("height")]
        public double? Height { get; set; }

        [BsonElement("depth")]
        public double? Depth { get; set; }
    }
}