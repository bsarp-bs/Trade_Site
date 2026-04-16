using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Demand_Application.Feature.CQRS.Commands.OrderDetailCommands;
using Trade_Site_Demand_Application.Feature.CQRS.Handlers.OrderDetailHandlers;
using Trade_Site_Demand_Application.Feature.CQRS.Queries.OrderDetailQueries;

namespace Trade_Site_Demand_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;

        public OrderDetailController
            (CreateOrderDetailCommandHandler createOrderDetailCommandHandler, 
            DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler, 
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, 
            GetOrderDetailQueryHandler getOrderDetailQueryHandler, 
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler)
        {
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _getOrderDetailQueryHandler.Handle();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }
    }
}
