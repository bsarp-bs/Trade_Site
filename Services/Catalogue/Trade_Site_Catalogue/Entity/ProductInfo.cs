using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Trade_Site_Catalogue.Entity
{
    public class ProductInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductInfoID { get; set; }
        public string ProductDesc { get; set; }
        public string ProductDetailDesc { get; set; }
    }
}
