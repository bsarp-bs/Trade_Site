using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_Demand_Application.Feature.CQRS.Queries.AdressQueries
{
    public class GetOrderAdressByIdQuery
    {

        public int Id { get; set; }

        public GetOrderAdressByIdQuery(int _id)
        {
            Id = _id;
        }


       
    }
}
