using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.Mediator.Commands.OrderMainCommands
{
    public class UpdateOrderMainCommand : IRequest
    {
        public int OrderMainID { get; set; }
        public string UserID { get; set; }

        public int TotalPrice { get; set; }
        public DateTime OrderMainDate { get; set; }
    }
}
