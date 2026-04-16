using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.OrderDetailCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IGenericInterface<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IGenericInterface<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        { 
            var value = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailID);
            if (value != null) {

                value.ProductName = updateOrderDetailCommand.ProductName;
                value.ProductPrice = updateOrderDetailCommand.ProductPrice;
                value.ProductAmount = updateOrderDetailCommand.ProductAmount;
                value.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
                value.OrderMainID = updateOrderDetailCommand.OrderMainID;
                value.ProductID = updateOrderDetailCommand.ProductID;


                await _repository.UpdateAsync(value);
            }
        }
    }
}
