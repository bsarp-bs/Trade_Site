using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.AdressCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers
{
    public class DeleteOrderAdressCommandHandler
    {
        private readonly IGenericInterface<OrderAdress> _genericinterface;

        public DeleteOrderAdressCommandHandler(IGenericInterface<OrderAdress> genericinterface)
        {
            _genericinterface = genericinterface;
        }

        public async Task Handle(DeleteOrderAdressCommand _deleteOrderAdressCommand)
        { 
            var value = await _genericinterface.GetByIdAsync(_deleteOrderAdressCommand.Id);
            if (value != null)
            {
                await _genericinterface.DeleteAsync(value);
            }
        }
    }
}
