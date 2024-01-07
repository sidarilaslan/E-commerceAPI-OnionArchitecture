using E_commerceAPI.Application.CustomAttributes;
using E_commerceAPI.Application.Enums;
using E_commerceAPI.Application.Features.Brands.Commands.CreateBrand;
using E_commerceAPI.Application.Features.Brands.Commands.DeleteBrand;
using E_commerceAPI.Application.Features.Brands.Commands.HardDeleteBrand;
using E_commerceAPI.Application.Features.Brands.Commands.UpdateBrand;
using E_commerceAPI.Application.Features.Brands.Queries.GetAllBrand;
using E_commerceAPI.Application.Features.Brands.Queries.GetByIdBrand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : BaseController
    {
        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Write, Definition = "Create Brand", Menu = "Brands")]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand createBrandCommand)
        {
            var response = await Mediator.Send(createBrandCommand);
            return Ok(response);
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get All Brand", Menu = "Brands")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBrandQuery getAllBrandQuery)
        {
            var response = await Mediator.Send(getAllBrandQuery);
            return Ok(response);
        }
        [AuthorizeDefinition(ActionType = ActionType.Read, Definition = "Get Brand", Menu = "Brands")]
        [HttpGet("{BrandId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
        {
            var response = await Mediator.Send(getByIdBrandQuery);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefinition(ActionType = ActionType.Update, Definition = "Update Brand", Menu = "Brands")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            var response = await Mediator.Send(updateBrandCommand);
            return Ok(response);
        }

        [HttpDelete("{BrandId}")]
        [AuthorizeDefinition(ActionType = ActionType.Delete, Definition = "Delete Brand", Menu = "Brands")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBrandCommand deleteBrandCommand)
        {
            var response = await Mediator.Send(deleteBrandCommand);
            return Ok(response);
        }

        [HttpDelete("[action]/{BrandId}")]
        [AuthorizeDefinition(ActionType = ActionType.Delete, Definition = "Hard Delete Brand", Menu = "Brands")]
        public async Task<IActionResult> HardDelete([FromRoute] HardDeleteBrandCommand hardDeleteBrandCommand)
        {
            var response = await Mediator.Send(hardDeleteBrandCommand);
            return Ok(response);
        }
    }
}
