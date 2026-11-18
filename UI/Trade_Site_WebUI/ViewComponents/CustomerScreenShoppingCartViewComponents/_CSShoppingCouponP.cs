using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenShoppingCartViewComponents
{
    public class _CSShoppingCouponP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public _CSShoppingCouponP(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _contextAccessor = contextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = _contextAccessor.HttpContext?.User?.FindFirst("access_token")?.Value;

            if(string.IsNullOrEmpty(token))
            {
                return View(new UI_CartTotalDto
                {

                    CartItems = new List<UI_CartItemDto>()

                });
            }

            var client = _httpClientFactory.CreateClient();

             client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

             var cart = await client.GetFromJsonAsync<UI_CartTotalDto>("https://localhost:7130/api/Cart");

             if (cart == null)
             {
                 cart = new UI_CartTotalDto();
             }

             cart.CartItems ??= new List<UI_CartItemDto>();

             return View(cart); 
        }
    }
}
