using Microsoft.AspNetCore.Mvc;
using Trade_Site_WebUI_Dto_Layer.UI_Category_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenViewComponents
{
    public class _CategoriesP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CategoriesP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var categoriesresponse = await client.GetFromJsonAsync<List<UI_ShowCategoryDto>>("https://localhost:7200/api/Category");

            var productsresponse = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            if (categoriesresponse == null || productsresponse == null)
            {
                return View(new List<UI_ShowCategoryDto>());
            }


            foreach (var item in categoriesresponse)
            {
                item.CategoryCount = productsresponse.Count(p => p.CategoryID == item.CategoryID.ToString());
            }

            return View(categoriesresponse);
        }
    }
}
