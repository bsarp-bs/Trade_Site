using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.CQRS.Commands.AdressCommands
{
    public class DeleteOrderAdressCommand
    {
        public DeleteOrderAdressCommand(int _id)
        {
            Id = _id;
        }

        public int Id { get; set; }
    }
}
