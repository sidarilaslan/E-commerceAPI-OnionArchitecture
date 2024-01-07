using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using E_commerceAPI.Application.Features.Categories.Commands.CreateCategory;
using E_commerceAPI.Application.Features.Categories.Commands.DeleteCategory;
using E_commerceAPI.Application.Features.Categories.Commands.HardDeleteCategory;
using E_commerceAPI.Application.Features.Categories.Commands.UpdateCategory;
using E_commerceAPI.Application.Features.Categories.Queries.GetAllCategory;
using E_commerceAPI.Application.Features.Categories.Queries.GetByIdCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : BaseController
    {
        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Write, Definition = "Create Category", Menu = "Categories")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {

            var response = await Mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get All Category", Menu = "Categories")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQuery getAllCategoryQuery)
        {
            var response = await Mediator.Send(getAllCategoryQuery);
            return Ok(response);
        }

        [HttpGet("{CategoryId}")]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get Category", Menu = "Categories")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
        {
            var response = await Mediator.Send(getByIdCategoryQuery);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefinition(ActionType = ActionType.Update, Definition = "Update Category", Menu = "Categories")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await Mediator.Send(updateCategoryCommand);
            return Ok(response);
        }

        [HttpDelete("{CategoryId}")]
        [AuthorizeDefinition(ActionType = ActionType.Delete, Definition = "Delete Category", Menu = "Categories")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommand deleteCategoryCommand)
        {
            var response = await Mediator.Send(deleteCategoryCommand);
            return Ok(response);
        }

        [HttpDelete("[action]/{CategoryId}")]
        [AuthorizeDefinition(ActionType = ActionType.Delete, Definition = "Hard Delete Category", Menu = "Categories")]
        public async Task<IActionResult> HardDelete([FromRoute] HardDeleteCategoryCommand hardDeleteCategoryCommand)
        {
            var response = await Mediator.Send(hardDeleteCategoryCommand);
            return Ok(response);
        }
    }
}
