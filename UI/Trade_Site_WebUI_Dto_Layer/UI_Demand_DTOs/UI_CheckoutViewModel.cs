using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs;

namespace Trade_Site_WebUI_Dto_Layer.UI_Demand_DTOs
{
    public class UI_CheckoutViewModel
    {
        public string District { get; set; }
        public string City { get; set; }
        public string Desc { get; set; }
        public UI_CartTotalDto Cart { get; set; } = new();
    }
}
