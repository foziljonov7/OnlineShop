using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SoldController : ControllerBase
    {
        private readonly ISoldProductService service;

        public SoldController(ISoldProductService service)
            => this.service = service;

        [HttpGet("Solds")]
        public async Task<IActionResult> GetSoldProucts()
            => Ok(await service.GetSoldProducts());

        [HttpGet("Sold/{id}")]
        public async Task<IActionResult> GetSoldProduct([FromRoute] Guid id)
        {
            var request = await service.GetSoldProduct(id);

            if (request is null)
                return NotFound($"Not found: {request.Id}");

            return Ok(request);
        }

        [HttpGet("ReturnSoldProduct/{id}")]
        public async Task<IActionResult> GetReturnSoldProduct(
            [FromRoute] Guid id,
            int quantity)
        {
            var request = await service.GetReturnSoldProduct(id, quantity);

            if (request.productId == Guid.Empty)
                return NotFound($"Not found {request.productId}");

            return Ok(request);
        }
    }
}
