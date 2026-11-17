using MediatR;
using Trade_Site_Demand_Application.Feature.Mediator.Querys.OrderMainQuerys;
using Trade_Site_Demand_Application.Feature.Mediator.Results.OrderMainResults;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers
{
    public class GetOrderMainByUserIdQueryHandler : IRequestHandler<GetOrderMainByUserIdQuery, List<GetOrderMainQueryResult>>
    {
        private readonly IGenericInterface<OrderMain> _genericInterface;

        public GetOrderMainByUserIdQueryHandler(IGenericInterface<OrderMain> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        public async Task<List<GetOrderMainQueryResult>> Handle(GetOrderMainByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orderMains = await _genericInterface.GetAsync();

            var results = orderMains
                .Where(x => x.UserID == request.UserId)
                .Select(x => new GetOrderMainQueryResult
                {
                    OrderMainID = x.OrderMainID,
                    UserID = x.UserID,
                    TotalPrice = x.TotalPrice,
                    OrderMainDate = x.OrderMainDate,
                    OrderStatus = "Hazirlaniyor"
                }).ToList();

            return results;
        }
    }
}
