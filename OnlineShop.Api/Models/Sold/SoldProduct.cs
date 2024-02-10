namespace OnlineShop.Api.Models.Sold
{
    public class SoldProduct
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
