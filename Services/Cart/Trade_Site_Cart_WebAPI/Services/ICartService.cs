using Trade_Site_Cart_WebAPI.DTOs;

namespace Trade_Site_Cart_WebAPI.Services
{
    public interface ICartService
    {
        Task SaveCart(CartTotalDto cartTotalDto);
        Task DeleteCart(string userid);
        Task<CartTotalDto> GetCart(string userid);

    }
}
