using OnlineShop.Api.Dtos.ImageDtos;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Api.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
