namespace Trade_Site_Cart_WebAPI.DTOs
{
    public class CartTotalDto
    {
        public string? UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int? DRate { get; set; }
        public List<CartItemDto> CartItems { get; set; } = new();
        public int TotalPrice { get => CartItems.Sum(x => x.Price * x.Quantity); }
    }
}
