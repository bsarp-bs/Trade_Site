using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_WebUI_Dto_Layer.UI_Demand_DTOs;

namespace Trade_Site_WebUI.Areas.AdminArea.Controllers
{
    [AllowAnonymous]
    [Area("AdminArea")]
    public class AdminOrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AdminOrderIndex()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Orders";
            ViewBag.v3 = "Orders List";
            ViewBag.v4 = "Orders List";

            var client = _httpClientFactory.CreateClient();
            var values = await client.GetFromJsonAsync<List<UI_GetOrderMainDto>>("https://localhost:7016/api/OrderMain");

            if (values == null)
            {
                return BadRequest();
            }

            return View(values);
        }

        public async Task<IActionResult> OrderDetail(int id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Orders";
            ViewBag.v3 = "Order Detail";
            ViewBag.v4 = "Order Detail";
            ViewBag.OrderMainID = id;

            var client = _httpClientFactory.CreateClient();
            var values = await client.GetFromJsonAsync<List<UI_GetOrderDetailDto>>(
                $"https://localhost:7016/api/OrderDetail/GetByOrderMainId/{id}");

            if (values == null)
            {
                return BadRequest();
            }

            return View(values);
        }
    }
}
