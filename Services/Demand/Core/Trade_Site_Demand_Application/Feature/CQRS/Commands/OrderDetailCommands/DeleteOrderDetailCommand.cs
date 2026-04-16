using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand
    {
        public DeleteOrderDetailCommand(int _id)
        {
            Id = _id;
        }

        public int Id { get; set; }
    }
}
