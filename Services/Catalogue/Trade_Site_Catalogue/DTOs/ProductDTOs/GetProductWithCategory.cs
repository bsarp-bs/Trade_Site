using Trade_Site_Catalogue.DTOs.CategoryDTOs;

namespace Trade_Site_Catalogue.DTOs.ProductDTOs
{
    public class GetProductWithCategory
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductUrl { get; set; }
        public string ProductDesc { get; set; }


        public string CategoryID { get; set; }

        public string ProductPhotoID { get; set; }

        public string ProductInfoID { get; set; }

        public ShowCategoryDto Category { get; set; }
    }
}
