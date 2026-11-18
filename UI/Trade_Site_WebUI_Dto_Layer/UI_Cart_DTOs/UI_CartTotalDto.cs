using System;
using System.Collections.Generic;
using System.Text;

namespace Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs
{
    public class UI_CartTotalDto
    {
        public string? UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int? DRate { get; set; }
        public List<UI_CartItemDto> CartItems { get; set; } = new();
        public int TotalPrice { get => CartItems.Sum(x => x.Price * x.Quantity); }
    }
}
