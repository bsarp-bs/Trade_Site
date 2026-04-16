using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Results.OrderDetailResults;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IGenericInterface<OrderDetail> _orderDetailRepository;

        public GetOrderDetailQueryHandler(IGenericInterface<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        { 
            var value = await _orderDetailRepository.GetAsync();

            return value.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailID = x.OrderDetailID,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductAmount = x.ProductAmount,
                ProductTotalPrice = x.ProductTotalPrice,
                OrderMainID = x.OrderMainID
            }).ToList();

        }
    }
}
