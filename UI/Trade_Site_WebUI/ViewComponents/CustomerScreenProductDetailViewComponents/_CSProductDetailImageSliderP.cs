using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenProductDetailViewComponents
{
    public class _CSProductDetailImageSliderP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CSProductDetailImageSliderP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7200/api/Product/" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UI_UpdateProductDto>(jsondata);

                return View(value);
            }

            return View();
        }
    }
}
