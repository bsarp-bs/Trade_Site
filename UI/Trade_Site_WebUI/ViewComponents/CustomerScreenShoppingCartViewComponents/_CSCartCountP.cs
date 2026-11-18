using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenShoppingCartViewComponents
{
    public class _CSCartCountP : ViewComponent
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public _CSCartCountP(IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory)
        {
            _contextAccessor = contextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = _contextAccessor.HttpContext?.User?.FindFirst("access_token")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return View(0);
            }

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var cart = await client.GetFromJsonAsync<UI_CartTotalDto>("https://localhost:7130/api/Cart");

            if (cart == null || cart.CartItems == null || !cart.CartItems.Any())
            {
                return View(0);
            }

            var TotalQuantity = cart.CartItems.Sum(x => x.Quantity);

            return View(TotalQuantity);
        }
    }
}
