using E_commerceAPI.Application.Constants;
using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using E_commerceAPI.Application.Features.Products.Commands.CreateProduct;
using E_commerceAPI.Application.Features.Products.Commands.DeleteProduct;
using E_commerceAPI.Application.Features.Products.Commands.HardDeleteProduct;
using E_commerceAPI.Application.Features.Products.Commands.RemoveProductImage;
using E_commerceAPI.Application.Features.Products.Commands.UpdateProduct;
using E_commerceAPI.Application.Features.Products.Commands.UploadProductImageFile;
using E_commerceAPI.Application.Features.Products.Queries.GetAllProduct;
using E_commerceAPI.Application.Features.Products.Queries.GetByIdProduct;
using E_commerceAPI.Application.Features.Products.Queries.GetProductImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : BaseController
    {
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Write, Definition = "Create Product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {

            var response = await Mediator.Send(createProductCommand);
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductQuery getAllProductQuery)
        {
            var response = await Mediator.Send(getAllProductQuery);
            return Ok(response);
        }

        [HttpGet("{ProductId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdProduct([FromRoute] GetByIdProductQuery getByIdProductQuery)
        {
            var response = await Mediator.Send(getByIdProductQuery);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Update, Definition = "Update Products")]
        public async Task<IActionResult> UpdateProduct([FromBody] StockUpdateProductCommand updateProductCommand)
        {
            var response = await Mediator.Send(updateProductCommand);
            return Ok(response);
        }

        [HttpDelete("{ProductId}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Delete, Definition = "Delete Products")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommand deleteProductCommand)
        {
            var response = await Mediator.Send(deleteProductCommand);
            return Ok(response);
        }

        [HttpDelete("[action]/{ProductId}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Delete, Definition = "Hard Delete Products")]
        public async Task<IActionResult> HardDeleteProduct([FromRoute] HardDeleteProductCommand hardDeleteProductCommand)
        {
            var response = await Mediator.Send(hardDeleteProductCommand);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Update, Definition = "Upload Product Image")]
        public async Task<IActionResult> UploadImage([FromQuery] UploadProductImageCommand uploadProductImageCommand)
        {
            uploadProductImageCommand.Files = Request.Form.Files;
            var response = await Mediator.Send(uploadProductImageCommand);
            return Ok();
        }

        [HttpGet("[action]/{ProductId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQuery getProductImagesQuery)
        {
            var response = await Mediator.Send(getProductImagesQuery);
            return Ok(response);
        }

        [HttpDelete("[action]/{ProductId}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Delete, Definition = "Delete Product Image")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommand removeProductImageCommand, [FromQuery] Guid imageId)
        {
            var response = await Mediator.Send(removeProductImageCommand);
            return Ok();
        }

    }
}
