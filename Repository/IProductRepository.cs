using MongoDB.Bson;

namespace mongo
{
    public interface IProductRepository
    {
        (string, double?) ProductWithLargestTotalValue(ObjectId categoryId);
        double GetAllProductsCumulativeVolume();
    }
}
