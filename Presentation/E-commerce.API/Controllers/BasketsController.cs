using E_commerceAPI.Application.Features.Baskets.Commands.AddItemToBasket;
using E_commerceAPI.Application.Features.Baskets.Commands.RemoveBasketItem;
using E_commerceAPI.Application.Features.Baskets.Commands.UpdateQuantity;
using E_commerceAPI.Application.Features.Baskets.Queries.GetBasketItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQuery getBasketItemsQuery)
        {
            var response = await Mediator.Send(getBasketItemsQuery);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommand addItemToBasketCommand)
        {
            var response = await Mediator.Send(addItemToBasketCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommand updateQuantityCommand)
        {
            var response = await Mediator.Send(updateQuantityCommand);
            return Ok(response);
        }

        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommand removeBasketItemCommand)
        {
            var response = await Mediator.Send(removeBasketItemCommand);
            return Ok(response);
        }
    }
}
