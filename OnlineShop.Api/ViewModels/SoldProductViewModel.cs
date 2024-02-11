using OnlineShop.Api.Models.Sold;

namespace OnlineShop.Api.ViewModels
{
    public class SoldProductViewModel
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public DateTime SoldDate { get; set; }

        public static explicit operator SoldProductViewModel(SoldProduct sold)
        {
            return new SoldProductViewModel
            {
                Id = sold.Id,
                Price = sold.Price,
                TotalPrice = sold.TotalPrice,
                Quantity = sold.Quantity,
                ProductId = sold.ProductId,
                SoldDate = sold.SoldDate
            };
        }
    }
}
