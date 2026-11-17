using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.Mediator.Querys.OrderMainQuerys;
using Trade_Site_Demand_Application.Feature.Mediator.Results.OrderMainResults;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers
{
    public class GetOrderMainQueryHandler : IRequestHandler<GetOrderMainQuery, List<GetOrderMainQueryResult>>
    {
        private readonly IGenericInterface<OrderMain> _genericInterface;

        public GetOrderMainQueryHandler(IGenericInterface<OrderMain> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        public async Task<List<GetOrderMainQueryResult>> Handle(GetOrderMainQuery request, CancellationToken cancellationToken)
        {
            var orderMains = await _genericInterface.GetAsync();

            var results = orderMains.Select(om => new GetOrderMainQueryResult
            {
                OrderMainDate = om.OrderMainDate,
                TotalPrice = om.TotalPrice,
                OrderMainID = om.OrderMainID,
                UserID = om.UserID,
                OrderStatus = "Hazirlaniyor"
            }).ToList();

            return results;
        }
    }
}
