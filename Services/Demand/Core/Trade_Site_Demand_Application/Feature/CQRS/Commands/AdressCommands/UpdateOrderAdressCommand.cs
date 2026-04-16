using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.CQRS.Commands.AdressCommands
{
    public class UpdateOrderAdressCommand
    {   
        public int OrderAdressID { get; set; }

        public string UserID { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Desc { get; set; }
    }
}
