using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Queries.OrderDetailQueries;
using Trade_Site_Demand_Application.Feature.CQRS.Results.OrderDetailResults;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IGenericInterface<OrderDetail> _orderDetailRepository;

        public GetOrderDetailByIdQueryHandler(IGenericInterface<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery _getOrderDetailByIdQuery)
        { 
            var value = await _orderDetailRepository.GetByIdAsync(_getOrderDetailByIdQuery.Id);

            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailID = value.OrderDetailID,
                ProductID = value.ProductID,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductAmount = value.ProductAmount,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderMainID = value.OrderMainID
            };
        }
    }
}
