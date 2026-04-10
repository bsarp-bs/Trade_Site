using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Trade_Site_Catalogue.Entity;

namespace Trade_Site_Catalogue.DTOs.ProductDTOs
{
    public class InsertProductDto
    {
        public string ProductName { get; set; }
        public int    ProductPrice { get; set; }
        public string ProductUrl { get; set; }
        public string ProductDesc { get; set; }


        public string CategoryID { get; set; }

        public string ProductPhotoID { get; set; }

        public string ProductInfoID { get; set; }
    }
}
