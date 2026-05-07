namespace Trade_Site_Cart_WebAPI.DTOs
{
    public class CartItemDto 
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
