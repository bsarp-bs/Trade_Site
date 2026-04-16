using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Domain
{
    public class OrderMain
    {
        public int OrderMainID { get; set; }
        public string UserID { get; set; }

        public int TotalPrice { get; set; }
        public DateTime OrderMainDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
