using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.OrderDetailCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IGenericInterface<OrderDetail> _orderDetailRepository;

        public DeleteOrderDetailCommandHandler(IGenericInterface<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(DeleteOrderDetailCommand _deleteOrderDetailCommand)
        {
            var value = await _orderDetailRepository.GetByIdAsync(_deleteOrderDetailCommand.Id);
            if (value != null)
            {
                await _orderDetailRepository.DeleteAsync(value);
            }
        }
    }
}
