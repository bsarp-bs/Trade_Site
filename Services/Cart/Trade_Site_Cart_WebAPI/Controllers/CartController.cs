using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Cart_WebAPI.DTOs;
using Trade_Site_Cart_WebAPI.LoginService;
using Trade_Site_Cart_WebAPI.Services;

namespace Trade_Site_Cart_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ICartService _cartService;

        public CartController(ILoginService loginService, ICartService cartService)
        {
            _loginService = loginService;
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = _loginService.GetUserId;
            var value = await _cartService.GetCart(userId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCart(CartTotalDto cartTotalDto)
        {
            var userId = _loginService.GetUserId;
            cartTotalDto.UserId = userId;
            await _cartService.SaveCart(cartTotalDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart()
        {
            var userId = _loginService.GetUserId;
            await _cartService.DeleteCart(userId);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Cart service is alive");
        }
    }
}
