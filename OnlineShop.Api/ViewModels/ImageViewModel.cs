using OnlineShop.Api.Models.ProductModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Api.ViewModels
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime Created { get; set; }
        public Guid ProductId { get; set; }
        public static explicit operator ImageViewModel(Image image)
        {
            return new ImageViewModel
            {
                Id = image.Id,
                FileName = image.FileName,
                FilePath = image.FilePath,
                Created = image.Created,
                ProductId = image.ProductId
            };
        }
    }
}
