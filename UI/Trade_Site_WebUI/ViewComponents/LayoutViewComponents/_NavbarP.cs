using Microsoft.AspNetCore.Mvc;
using Trade_Site_WebUI_Dto_Layer.UI_Category_DTOs;

namespace Trade_Site_WebUI.ViewComponents.LayoutViewComponents
{
    public class _NavbarP : ViewComponent
    {
        private readonly IHttpClientFactory _httpclient;

        public _NavbarP(IHttpClientFactory httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclient.CreateClient();

            var response = await client.GetFromJsonAsync<List<UI_ShowCategoryDto>>("https://localhost:7200/api/Category");

            return View(response);
        }
    }
}
