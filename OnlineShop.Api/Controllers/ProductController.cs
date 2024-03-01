using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Services;
using OnlineShop.Api.Validator.ProductValidators;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IValidator<CreateProductDto> createValidator;
        private readonly IValidator<UpdateProductDto> updateValidator;

        public ProductController(
            IProductService service,
            IValidator<CreateProductDto> createValidator,
            IValidator<UpdateProductDto> updateValidator)
        {
            this.service = service;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }
        [HttpGet("Products")]
        public async Task<IActionResult> GetProductsAsync()
            => Ok(await service.GetProductsAsync());

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductAsync([FromRoute] Guid id)
            => Ok(await service.GetProductAsync(id));

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductAsync(
            [FromBody] CreateProductDto newProduct)
        {
            var validationResult = await createValidator.ValidateAsync(newProduct);

            if (!validationResult.IsValid)
                return Ok(validationResult.Errors);

            var request = await service.CreateProductAsync(newProduct);
            return Ok(request);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateProductAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateProductDto product)
        {
            var validationResult = await updateValidator.ValidateAsync(product);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.UpdateProductAsync(id, product);
            return Ok(request);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
            => Ok(await service.DeleteProductAsync(id));

        [HttpGet("ProductByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryAsync([FromRoute] int categoryId)
            => Ok(await service.GetProductsByCategoryAsync(categoryId));

        [HttpGet("ProductsByPriceRangeAsync")]
        public async Task<IActionResult> GetProductsByPriceRangeAsync(
            double minPrice,
            double maxPrice)
                => Ok(await service.GetProductsByPriceRangeAsync(minPrice, maxPrice));

        [HttpGet("SalesProduct/{id}")]
        public async Task<IActionResult> SalesProductAsync(
            [FromRoute] Guid id,
            int quantity)
                => Ok(await service.SalesProductAsync(id, quantity));

        [HttpGet("ProductsWithImagesAsync")]
        public async Task<IActionResult> GetProductsWithImagesAsync()
            => Ok(await service.GetProductsWithImagesAsync());
    }
}
