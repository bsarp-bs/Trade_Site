using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.AdressCommands;
using Trade_Site_Demand_Application.Feature.CQRS.Handlers.AdressHandlers;
using Trade_Site_Demand_Application.Feature.CQRS.Queries.AdressQueries;

namespace Trade_Site_Demand_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderAddressController : ControllerBase
    {
        private readonly CreateOrderAdressCommandHandler _createOrderAdressCommandHandler;
        private readonly UpdateOrderAdressCommandHandler _updateOrderAdressCommandHandler;
        private readonly DeleteOrderAdressCommandHandler _deleteOrderAdressCommandHandler;
        private readonly GetOrderAdressByIdQueryHandler _getOrderAdressByIdQueryHandler;
        private readonly GetOrderAdressQueryHandler _getOrderAdressQueryHandler;

        public OrderAddressController
            (CreateOrderAdressCommandHandler createOrderAdressCommandHandler,
            UpdateOrderAdressCommandHandler updateOrderAdressCommandHandler,
            DeleteOrderAdressCommandHandler deleteOrderAdressCommandHandler,
            GetOrderAdressByIdQueryHandler getOrderAdressByIdQueryHandler,
            GetOrderAdressQueryHandler getOrderAdressQueryHandler)
        {
            _createOrderAdressCommandHandler = createOrderAdressCommandHandler;
            _updateOrderAdressCommandHandler = updateOrderAdressCommandHandler;
            _deleteOrderAdressCommandHandler = deleteOrderAdressCommandHandler;
            _getOrderAdressByIdQueryHandler = getOrderAdressByIdQueryHandler;
            _getOrderAdressQueryHandler = getOrderAdressQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _getOrderAdressQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var value = await _getOrderAdressByIdQueryHandler.Handle(new GetOrderAdressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderAdressCommand command)
        {
            await _createOrderAdressCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteOrderAdressCommandHandler.Handle(new DeleteOrderAdressCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderAdressCommand command)
        {
            await _updateOrderAdressCommandHandler.Handle(command);
            return Ok();
        }
    }
}