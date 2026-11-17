using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.Mediator.Commands.OrderMainCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers
{
    public class CreateOrderMainCommandHandler : IRequestHandler<CreateOrderMainCommand,int>
    {
        private readonly IGenericInterface<OrderMain> _genericInterface;

        public CreateOrderMainCommandHandler(IGenericInterface<OrderMain> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        public async Task<int> Handle(CreateOrderMainCommand request, CancellationToken cancellationToken)
        {
            var orderMain = new OrderMain
            {
                TotalPrice = request.TotalPrice,
                UserID = request.UserID,
                OrderMainDate = request.OrderMainDate
            };

            await _genericInterface.AddAsync(orderMain);

            return orderMain.OrderMainID;
        }

    }
}
