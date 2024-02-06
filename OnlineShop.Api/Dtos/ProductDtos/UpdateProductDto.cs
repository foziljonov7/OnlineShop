using OnlineShop.Api.Dtos.ImageDtos;

namespace OnlineShop.Api.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}
