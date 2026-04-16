using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.AdressCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers
{
    public class CreateOrderAdressCommandHandler
    {
        private readonly IGenericInterface<OrderAdress> _genericinterface;

        public CreateOrderAdressCommandHandler(IGenericInterface<OrderAdress> genericinterface)
        {
            _genericinterface = genericinterface;
        }

        public async Task Handle(CreateOrderAdressCommand command)
        {

            await _genericinterface.AddAsync(new OrderAdress
            {
                City = command.City,
                Desc = command.Desc,
                District = command.District,
                UserID = command.UserID
            });

        }
    }
}

