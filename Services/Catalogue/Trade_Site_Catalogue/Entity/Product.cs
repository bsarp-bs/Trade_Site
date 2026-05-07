using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Trade_Site_Catalogue.Entity
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductUrl { get; set; }
        public string ProductDesc { get; set; }


        public string CategoryID { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
        

        public string ProductPhotoID { get; set; }
        [BsonIgnore]
        public ProductPhoto ProductPhoto { get; set; }



        public string ProductInfoID { get; set; }
        [BsonIgnore]
        public ProductInfo ProductInfo { get; set; }


    }
}
