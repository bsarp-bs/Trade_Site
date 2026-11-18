using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_ProductInfo_DTOs;

namespace Trade_Site_WebUI.Areas.AdminArea.Controllers
{
    [AllowAnonymous]
    [Area("AdminArea")]
    public class AdminProductInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminProductInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AdminProductInfoIndex()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "ProductInfos";
            ViewBag.v3 = "ProductInfo List";
            ViewBag.v4 = "ProductInfo List";

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<List<UI_GetProductInfoDto>>("https://localhost:7200/api/ProductInfo");

            var productresponse = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            response?.ForEach(x =>
            {
                x.ProductName = productresponse?.FirstOrDefault(p => p.ProductID == x.ProductID)?.ProductName;
            });

            if (response == null)
            {
                return BadRequest();
            }
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddProductInfo()
        {

            var client = _httpClientFactory.CreateClient();

            var productresponse = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.ProductsList = productresponse?.Select(x => new SelectListItem
            {
                Value = x.ProductID,
                Text = x.ProductName
            }).ToList();

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddProductInfo(UI_AddProductInfoDto addmodel)
        {
            var client = _httpClientFactory.CreateClient();

            var productinforesponse = await client.PostAsJsonAsync("https://localhost:7200/api/ProductInfo", addmodel);

            var productresponse = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.ProductsList = productresponse?.Select(x => new SelectListItem
            {
                Value = x.ProductID,
                Text = x.ProductName
            }).ToList();

            if (!productinforesponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Ürün eklenemedi.");
                return View(addmodel);
            }

            return RedirectToAction("AdminProductInfoIndex", "AdminProductInfo", new { area = "AdminArea" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductInfo(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<UI_UpdateProductInfoDto>($"https://localhost:7200/api/ProductInfo/{id}");

            var productresponse = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.ProductsList = productresponse?.Select(x => new SelectListItem
            {
                Value = x.ProductID,
                Text = x.ProductName
            }).ToList();

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductInfo(UI_UpdateProductInfoDto updateModel)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PutAsJsonAsync("https://localhost:7200/api/ProductInfo", updateModel);

            var productresponse = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.ProductsList = productresponse?.Select(x => new SelectListItem
            {
                Value = x.ProductID,
                Text = x.ProductName
            }).ToList();

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Ürün güncellenemedi.");
                return View(updateModel);
            }

            return RedirectToAction("AdminProductInfoIndex", "AdminProductInfo", new { area = "AdminArea" });
        }

        public async Task<IActionResult> DeleteProductInfo(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7200/api/ProductInfo/{id}");
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Ürün silinemedi.");
                return RedirectToAction("AdminProductInfoIndex", "AdminProductInfo", new { area = "AdminArea" });
            }
            return RedirectToAction("AdminProductInfoIndex", "AdminProductInfo", new { area = "AdminArea" });
        }
    }
}