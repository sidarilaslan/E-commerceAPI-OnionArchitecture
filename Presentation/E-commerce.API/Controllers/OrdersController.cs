using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using E_commerceAPI.Application.Features.Orders.Commands.CompleteOrder;
using E_commerceAPI.Application.Features.Orders.Commands.CreateOrder;
using E_commerceAPI.Application.Features.Orders.Queries.GetAllOrders;
using E_commerceAPI.Application.Features.Orders.Queries.GetOrderById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : BaseController
    {
        [HttpGet("{OrderId}")]
        public async Task<ActionResult> GetOrderById([FromRoute] GetOrderByIdQuery getOrderByIdQuery)
        {
            var response = await Mediator.Send(getOrderByIdQuery);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery getAllOrdersQuery)
        {
            var response = await Mediator.Send(getAllOrdersQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await Mediator.Send(createOrderCommand);
            return Ok(response);
        }

        [HttpGet("[action]/{OrderId}")]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Complete Order", Menu = "Orders")]
        public async Task<ActionResult> CompleteOrder([FromRoute] CompleteOrderCommand completeOrderCommand)
        {
            var response = await Mediator.Send(completeOrderCommand);
            return Ok(response);
        }
    }
}
