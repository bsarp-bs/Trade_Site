using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs;

namespace Trade_Site_WebUI.Controllers
{
    [Authorize]
    public class CustomerScreenShoppingCartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerScreenShoppingCartController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult CustomerScreenShoppingCartIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest();
            }

            var token = User.FindFirst("access_token")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var cart = await client.GetFromJsonAsync<UI_CartTotalDto>("https://localhost:7130/api/Cart");

            if (cart == null)
            {
                cart = new UI_CartTotalDto();
            }

            cart.CartItems ??= new List<UI_CartItemDto>();

            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }

            var response = await client.PostAsJsonAsync("https://localhost:7130/api/Cart", cart);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return RedirectToAction("CustomerScreenShoppingCartIndex");
        }



        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest();
            }

            var token = User.FindFirst("access_token")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var cart = await client.GetFromJsonAsync<UI_CartTotalDto>("https://localhost:7130/api/Cart");

            if (cart == null)
            {
                cart = new UI_CartTotalDto();
            }

            cart.CartItems ??= new List<UI_CartItemDto>();

            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);

            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity -= 1;
                }
                else
                {
                    cart.CartItems.Remove(existingItem);
                }
            }

            var response = await client.PostAsJsonAsync("https://localhost:7130/api/Cart", cart);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return RedirectToAction("CustomerScreenShoppingCartIndex");
        }


        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(string productId) 
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest();
            }

            var token = User.FindFirst("access_token")?.Value;

            if(string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var cart = await client.GetFromJsonAsync<UI_CartTotalDto>("https://localhost:7130/api/Cart");

            if (cart == null)
            {
                cart = new UI_CartTotalDto();
            }

            cart.CartItems ??= new List<UI_CartItemDto>();

            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);

            if (existingItem != null)
            {
                cart.CartItems.Remove(existingItem);
            }

            var response = await client.PostAsJsonAsync("https://localhost:7130/api/Cart", cart);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return RedirectToAction("CustomerScreenShoppingCartIndex");
        }

    }
}
