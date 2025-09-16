using MongoDB.Bson;

namespace DotNetCore.DataContext
{
    public class ProductsCollection
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
    }
}
