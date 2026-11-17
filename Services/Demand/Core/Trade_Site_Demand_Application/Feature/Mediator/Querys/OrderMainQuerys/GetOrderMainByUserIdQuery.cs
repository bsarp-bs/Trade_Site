using MediatR;
using Trade_Site_Demand_Application.Feature.Mediator.Results.OrderMainResults;

namespace Trade_Site_Demand_Application.Feature.Mediator.Querys.OrderMainQuerys
{
    public class GetOrderMainByUserIdQuery : IRequest<List<GetOrderMainQueryResult>>
    {
        public string UserId { get; set; }

        public GetOrderMainByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
