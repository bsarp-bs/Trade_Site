using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs
{
    public class UI_CartItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
