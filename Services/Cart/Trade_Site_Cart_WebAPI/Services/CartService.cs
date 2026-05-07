using System.Text.Json;
using Trade_Site_Cart_WebAPI.Context_Settings;
using Trade_Site_Cart_WebAPI.DTOs;

namespace Trade_Site_Cart_WebAPI.Services
{
    public class CartService : ICartService
    {
        private readonly RedisService redisService;

        public CartService(RedisService _redisService)
        {
            this.redisService = _redisService;
        }

        public async Task DeleteCart(string userid)
        {
            await redisService.GetDatabase().KeyDeleteAsync(userid);
        }

        public async Task<CartTotalDto> GetCart(string userid)
        {
            var value = await redisService.GetDatabase().StringGetAsync(userid);

            if (value.IsNullOrEmpty)
            {
                return new CartTotalDto
                {
                    UserId = userid,
                    CartItems = new List<CartItemDto>()
                };
            }

            return JsonSerializer.Deserialize<CartTotalDto>(value.ToString()) ?? new CartTotalDto
            {
                UserId = userid,
                CartItems = new List<CartItemDto>()
            };
        }

        public async Task SaveCart(CartTotalDto cartTotalDto)
        {
            var json = JsonSerializer.Serialize(cartTotalDto);
            await redisService.GetDatabase().StringSetAsync(cartTotalDto.UserId, json);
        }
    }
}
