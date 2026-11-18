using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trade_Site_WebUI_Dto_Layer.UI_ProductInfo_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenProductDetailViewComponents
{
    public class _CSProductDetailTabOneP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CSProductDetailTabOneP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = client.GetAsync("https://localhost:7200/api/ProductInfo/GetInfoByProductID?id=" + id);

            if (response.Result.IsSuccessStatusCode)
            {
                var json = response.Result.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<UI_GetProductInfoDto>(json);

                return View(result);
            }

            return View();
        }
    }
}
