using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_WebUI_Dto_Layer.UI_Demand_DTOs
{
    public class UI_CreateOrderMainDto
    {
        public string UserID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderMainDate { get; set; }
    }
}
