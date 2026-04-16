using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int ProductAmount { get; set; }

        public int ProductTotalPrice { get; set; }

        public int OrderMainID { get; set; }
    }
}
