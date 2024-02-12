using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet("Products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            return Ok(await service.GetProductsAsync());
        }
    }
}
