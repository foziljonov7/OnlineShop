using OnlineShop.Domain.Models.Status;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models.ProductModels
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Image> Images { get; set; }
        public IsPresent Status { get; set; }
    }
}
