using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.OrderDetailCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IGenericInterface<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IGenericInterface<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        { 
            await _repository.AddAsync(new OrderDetail
            { 
                ProductName = createOrderDetailCommand.ProductName,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                ProductAmount = createOrderDetailCommand.ProductAmount,
                ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice,
                OrderMainID = createOrderDetailCommand.OrderMainID,
                ProductID = createOrderDetailCommand.ProductID
            });
        }
    }
}
