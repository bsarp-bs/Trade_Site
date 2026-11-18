    using Microsoft.AspNetCore.Mvc;
using Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenProductListViewComponents
{
    public class _CSProductListP : ViewComponent
    {

        private readonly IHttpClientFactory _httpclient;

        public _CSProductListP(IHttpClientFactory httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
             var client = _httpclient.CreateClient();

             var response =await client.GetFromJsonAsync<List<UI_GetProductWithCategoryDto>>("https://localhost:7200/api/Product/GetProductsWithCategory?id=" + id);

             return View(response);
        }
    }
}
