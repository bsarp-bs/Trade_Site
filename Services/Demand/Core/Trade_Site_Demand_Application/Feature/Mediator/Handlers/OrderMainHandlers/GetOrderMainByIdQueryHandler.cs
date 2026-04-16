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
    public class GetOrderMainByIdQueryHandler : IRequestHandler<GetOrderMainByIdQuery, GetOrderMainByIdQueryResult>
    {
        private readonly IGenericInterface<OrderMain> _genericInterface;

        public GetOrderMainByIdQueryHandler(IGenericInterface<OrderMain> genericInterface)
        {
            _genericInterface = genericInterface;
        }


        public async Task<GetOrderMainByIdQueryResult> Handle(GetOrderMainByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _genericInterface.GetByIdAsync(request.ID);

            var result = new GetOrderMainByIdQueryResult
            {
                OrderMainDate = value.OrderMainDate,
                TotalPrice = value.TotalPrice,
                UserID = value.UserID
            };

            return result;
        }
    }
}
