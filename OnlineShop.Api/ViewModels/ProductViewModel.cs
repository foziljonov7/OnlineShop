using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Models.Status;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Api.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Quantity { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<Image> Images { get; set; }
        public IsPresent Status { get; set; }

        public static explicit operator ProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Description = product.Description,
                Created = product.Created,
                Updated = product.Updated,
                Quantity = product.Quantity,
                Category = (CategoryViewModel)product.Category,
                Images = product.Images.ToList(),
                Status = product.Status
            };
        }
    }
}
