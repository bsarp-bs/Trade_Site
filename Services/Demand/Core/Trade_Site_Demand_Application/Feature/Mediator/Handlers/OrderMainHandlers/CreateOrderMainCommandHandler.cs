using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.Mediator.Commands.OrderMainCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers
{
    public class CreateOrderMainCommandHandler : IRequestHandler<CreateOrderMainCommand>
    {
        private readonly IGenericInterface<OrderMain> _genericInterface;

        public CreateOrderMainCommandHandler(IGenericInterface<OrderMain> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        public async Task<Unit> Handle(CreateOrderMainCommand request, CancellationToken cancellationToken)
        {
            await _genericInterface.AddAsync(new OrderMain
            {
                TotalPrice = request.TotalPrice,
                UserID = request.UserID,
                OrderMainDate = request.OrderMainDate
            });

            return Unit.Value;
        }

    }
}
