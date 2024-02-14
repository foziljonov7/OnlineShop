using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
            => this.service = service;

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoriesAsync()
            => Ok(await service.GetCategoriesAsync());

        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        => Ok(await service.GetCategoryAsync(id));

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] string name)
        {
            if (name is null)
                return BadRequest("Name cannot be null");

            return Ok(await service.CreateCategoryAsync(name));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
            => Ok(await service.DeleteCategoryAsync(id));
    }
}
