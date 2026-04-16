using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Demand_Application.Feature.Mediator.Commands.OrderMainCommands;
using Trade_Site_Demand_Application.Feature.Mediator.Querys.OrderMainQuerys;

namespace Trade_Site_Demand_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMainController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderMainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _mediator.Send(new GetOrderMainQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediator.Send(new GetOrderMainByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderMainCommand createOrderMainCommand)
        {
            await _mediator.Send(createOrderMainCommand);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderMainCommand updateOrderMainCommand)
        {
            await _mediator.Send(updateOrderMainCommand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderMainCommand(id));
            return Ok();
        }
    }
}
        