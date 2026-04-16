using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Queries.AdressQueries;
using Trade_Site_Demand_Application.Feature.CQRS.Results.AdressResults;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers
{
    public class GetOrderAdressByIdQueryHandler
    {
        private readonly IGenericInterface<OrderAdress> _genericInterface;
        public GetOrderAdressByIdQueryHandler(IGenericInterface<OrderAdress> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        public async Task<GetOrderAdressByIdQueryResult> Handle(GetOrderAdressByIdQuery query)
        { 
            var value = await _genericInterface.GetByIdAsync(query.Id);

            return new GetOrderAdressByIdQueryResult
            {
                OrderAdressID = value.OrderAdressID,
                UserID = value.UserID,
                District = value.District,
                City = value.City,
                Desc = value.Desc
            };
        }
    }
}
