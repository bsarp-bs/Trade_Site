using Microsoft.AspNetCore.Mvc;
using Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenViewComponents
{
    public class _ProductsP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductsP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var response =await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            return View(response);
        }
    }
}
