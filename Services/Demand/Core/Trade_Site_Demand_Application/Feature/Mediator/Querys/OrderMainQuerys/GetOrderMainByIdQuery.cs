using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.Mediator.Results.OrderMainResults;

namespace Trade_Site_Demand_Application.Feature.Mediator.Querys.OrderMainQuerys
{
    public class GetOrderMainByIdQuery : IRequest<GetOrderMainByIdQueryResult>
    {
        public GetOrderMainByIdQuery(int _iD)
        {
            ID = _iD;
        }

        public int ID { get; set; }
    
    }
}
