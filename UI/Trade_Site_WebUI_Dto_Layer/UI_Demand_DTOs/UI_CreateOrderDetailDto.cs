using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_WebUI_Dto_Layer.UI_Demand_DTOs
{
    public class UI_CreateOrderDetailDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public int ProductTotalPrice { get; set; }
        public int OrderMainID { get; set; }
    }
}
