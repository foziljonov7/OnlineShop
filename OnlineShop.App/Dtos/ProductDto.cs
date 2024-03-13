namespace OnlineShop.App.Dtos
{
    public class ProductDto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
