using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models.ProductModels
{
    public class Image
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime Created { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
