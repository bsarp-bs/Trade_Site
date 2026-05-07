using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs
{
    public class UI_AddProductDto
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductUrl { get; set; }
        public string ProductDesc { get; set; }

        public string CategoryID { get; set; }

        public string ProductPhotoID { get; set; }

        public string ProductInfoID { get; set; }
    }
}
