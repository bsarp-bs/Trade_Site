using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public GetOrderDetailByIdQuery(int _id)
        {
            Id = _id;
        }

        public int Id { get; set; }

    }
}
