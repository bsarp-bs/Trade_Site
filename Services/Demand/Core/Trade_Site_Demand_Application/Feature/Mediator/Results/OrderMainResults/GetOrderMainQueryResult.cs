using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.Mediator.Results.OrderMainResults
{
    public class GetOrderMainQueryResult
    {
        public int OrderMainID { get; set; }
        public string UserID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderMainDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
