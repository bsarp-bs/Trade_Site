using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Domain
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int ProductAmount { get; set; }

        public int ProductTotalPrice { get; set; }

        public int OrderMainID { get; set; }

        public OrderMain OrderMain { get; set; }

    }
}
