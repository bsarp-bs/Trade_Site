using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_Demand_DTOs;

namespace Trade_Site_WebUI.Controllers
{
    [Authorize]
    public class CustomerScreenCheckoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerScreenCheckoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> CustomerScreenCheckoutIndex()
        {
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

            var model = new UI_CheckoutViewModel
            {
                Cart = cart
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerScreenCheckoutIndex(UI_CheckoutViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var token = User.FindFirst("access_token")?.Value;

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
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

            var orderMainDto = new UI_CreateOrderMainDto
            {
                UserID = userId,
                TotalPrice = cart.TotalPrice,
                OrderMainDate = DateTime.Now
            };

            var orderMainResponse = await client.PostAsJsonAsync("https://localhost:7016/api/OrderMain", orderMainDto);

            if (!orderMainResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Siparis ana kaydi olusturulamadi.");
                model.Cart = cart;
                return View(model);
            }

            var orderMainId = await orderMainResponse.Content.ReadFromJsonAsync<int>();

            foreach (var item in cart.CartItems)
            {
                var orderDetailDto = new UI_CreateOrderDetailDto
                {
                    ProductID = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = item.Price,
                    ProductAmount = item.Quantity,
                    ProductTotalPrice = item.Price * item.Quantity,
                    OrderMainID = orderMainId
                };

                var orderDetailResponse = await client.PostAsJsonAsync("https://localhost:7016/api/OrderDetail", orderDetailDto);

                if (!orderDetailResponse.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Siparis detay kaydi olusturulamadi.");
                    model.Cart = cart;
                    return View(model);
                }
            }

            var addressDto = new UI_CreateOrderAddressDto
            {
                UserID = userId,
                City = model.City,
                District = model.District,
                Desc = model.Desc
            };

            var addressResponse = await client.PostAsJsonAsync("https://localhost:7016/api/OrderAddress", addressDto);

            if (!addressResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Adres kaydi olusturulamadi.");
                model.Cart = cart;
                return View(model);
            }

            var deleteCartResponse = await client.DeleteAsync("https://localhost:7130/api/Cart");

            if (!deleteCartResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Siparis olustu ama sepet temizlenemedi.");
                model.Cart = cart;
                return View(model);
            }

            TempData["OrderSuccess"] = "Siparisiniz basariyla olusturuldu.";
            return RedirectToAction("CustomerScreenShoppingCartIndex", "CustomerScreenShoppingCart");

        }
    }
}
