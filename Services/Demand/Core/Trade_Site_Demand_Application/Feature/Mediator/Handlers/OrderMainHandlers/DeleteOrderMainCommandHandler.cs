using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Demand_Application.Feature.Mediator.Commands.OrderMainCommands;
using Trade_Site_Demand_Application.Interface;
using Trade_Site_Demand_Domain;

namespace Trade_Site_Demand_Application.Feature.Mediator.Handlers.OrderMainHandlers
{
    public class DeleteOrderMainCommandHandler : IRequestHandler<DeleteOrderMainCommand>
    {
        private readonly IGenericInterface<OrderMain> _genericInterface;

        public DeleteOrderMainCommandHandler(IGenericInterface<OrderMain> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        public async Task<Unit> Handle(DeleteOrderMainCommand request, CancellationToken cancellationToken)
        {
            var value = await _genericInterface.GetByIdAsync(request.ID);

            await _genericInterface.DeleteAsync(value);

            return Unit.Value;

        }

    }
}
