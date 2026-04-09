using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Trade_Site_Catalogue.Entity
{
    public class ProductPhoto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductPhotoID { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }

    }
}
