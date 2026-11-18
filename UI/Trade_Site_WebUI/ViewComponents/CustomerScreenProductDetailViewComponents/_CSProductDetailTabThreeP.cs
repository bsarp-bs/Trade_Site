using Microsoft.AspNetCore.Mvc;
using Trade_Site_WebUI_Dto_Layer.UI_Comment_DTOs;

namespace Trade_Site_WebUI.ViewComponents.CustomerScreenProductDetailViewComponents
{
    public class _CSProductDetailTabThreeP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CSProductDetailTabThreeP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)    
        {
            ViewBag.ProductID = id;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<UI_GetCommentWProductID>>($"https://localhost:7276/api/Comment/GetCommentWithProduct?id={id}");

            if (response == null)
            {
                return View(new List<UI_GetCommentWProductID>());
            }
                return View(response);
        }
    }
}
