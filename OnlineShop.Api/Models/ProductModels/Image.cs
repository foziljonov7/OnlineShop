using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Api.Models.ProductModels
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
