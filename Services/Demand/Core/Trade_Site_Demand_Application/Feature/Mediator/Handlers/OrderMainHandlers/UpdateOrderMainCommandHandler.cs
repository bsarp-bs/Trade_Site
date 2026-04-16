using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.Mediator.Commands.OrderMainCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers
{
    public class UpdateOrderMainCommandHandler : IRequestHandler<UpdateOrderMainCommand>
    {
        private readonly IGenericInterface<OrderMain> _genericInterface;

        public async Task<Unit> Handle(UpdateOrderMainCommand request, CancellationToken cancellationToken)
        {
            var value = await _genericInterface.GetByIdAsync(request.OrderMainID);

            value.UserID = request.UserID;
            value.TotalPrice = request.TotalPrice;
            value.OrderMainDate = request.OrderMainDate;

            await _genericInterface.UpdateAsync(value);

            return Unit.Value;
        }
    }
}
