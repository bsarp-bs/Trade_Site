using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.Mediator.Commands.OrderMainCommands
{
    public class DeleteOrderMainCommand : IRequest
    {
        public DeleteOrderMainCommand(int _iD)
        {
            ID = _iD;
        }

        public int ID { get; set; }
    }
}
