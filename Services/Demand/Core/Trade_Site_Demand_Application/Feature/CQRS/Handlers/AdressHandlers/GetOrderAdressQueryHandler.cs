using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.CQRS.Results.AdressResults;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers
{
    public class GetOrderAdressQueryHandler
    {

        private readonly IGenericInterface<OrderAdress> _genericinterface;

        public GetOrderAdressQueryHandler(IGenericInterface<OrderAdress> genericinterface)
        {
            _genericinterface = genericinterface;
        }

        public async Task<List<GetOrderAdressQueryResult>> Handle() 
        {
            var value = await _genericinterface.GetAsync();

            return value.Select(x=> new GetOrderAdressQueryResult
            { 
                City = x.City,
                Desc = x.Desc,
                UserID = x.UserID,
                District = x.District,
            }).ToList();
        }
    }
}
