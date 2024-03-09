using OnlineShop.Domain.Models.Status;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models.ProductModels
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Image> Images { get; set; }
        public IsPresent Status { get; set; }
    }
}
