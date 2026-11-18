using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using Trade_Site_WebUI_Dto_Layer.UI_Demand_DTOs;

namespace Trade_Site_WebUI.Controllers
{
    [Authorize]
    public class CustomerScreenOrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerScreenOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var token = User.FindFirst("access_token")?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var values = await client.GetFromJsonAsync<List<UI_GetOrderMainDto>>(
                $"https://localhost:7016/api/OrderMain/GetByUser/{userId}");

            return View(values ?? new List<UI_GetOrderMainDto>());
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetail(int id)
        {
            var token = User.FindFirst("access_token")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var values = await client.GetFromJsonAsync<List<UI_GetOrderDetailDto>>(
                $"https://localhost:7016/api/OrderDetail/GetByOrderMainId/{id}");

            ViewBag.OrderMainID = id;
            ViewBag.OrderStatus = "Hazirlaniyor";

            return View(values ?? new List<UI_GetOrderDetailDto>());
        }
    }
}
