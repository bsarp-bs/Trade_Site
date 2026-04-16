using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.AdressCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers
{
    public class UpdateOrderAdressCommandHandler
    {
        private readonly IGenericInterface<OrderAdress> _orderAdressRepository;

        public UpdateOrderAdressCommandHandler(IGenericInterface<OrderAdress> orderAdressRepository)
        {
            _orderAdressRepository = orderAdressRepository;
        }

        public async Task Handle(UpdateOrderAdressCommand _updatecommand)
        {
            var value = await _orderAdressRepository.GetByIdAsync(_updatecommand.OrderAdressID);

            value.UserID = _updatecommand.UserID;
            value.District = _updatecommand.District;
            value.City = _updatecommand.City;
            value.Desc = _updatecommand.Desc;

            await _orderAdressRepository.UpdateAsync(value);

        }
    }
}
