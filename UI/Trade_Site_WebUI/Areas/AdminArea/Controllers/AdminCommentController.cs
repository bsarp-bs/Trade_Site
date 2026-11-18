using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trade_Site_WebUI_Dto_Layer.UI_Category_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_Comment_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_ProductInfo_DTOs;

namespace Trade_Site_WebUI.Areas.AdminArea.Controllers
{
    [AllowAnonymous]
    [Area("AdminArea")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AdminCommentIndex()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comments";
            ViewBag.v3 = "Comments List";
            ViewBag.v4 = "Comments List";

            var client = _httpClientFactory.CreateClient();
            var value = await client.GetFromJsonAsync<List<UI_ShowCommentDto>>("https://localhost:7276/api/Comment");

            var productresponse = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            value?.ForEach(x =>
            {
                x.ProductName = productresponse?.FirstOrDefault(p => p.ProductID == x.ProductID)?.ProductName;
            });

            if (value == null)
            {
                return BadRequest();
            }

            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> AddComment()
        {
            var client = _httpClientFactory.CreateClient();
            var productres = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.Products = productres?.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductID.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(UI_AddCommentDto model)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:7276/api/Comment", model);

            var productres = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.Products = productres?.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductID.ToString()
            }).ToList();

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Yorum eklenemedi.");
                return View(model);
            }

            return RedirectToAction("AdminCommentIndex", "AdminComment", new { area = "AdminArea" });
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7276/api/Comment/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("AdminCommentIndex", "AdminComment", new { area = "AdminArea" });

        }

        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<UI_UpdateCommentDto>($"https://localhost:7276/api/Comment/{id}");

            var productres = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.Products = productres?.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductID.ToString()
            }).ToList();

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UI_UpdateCommentDto updateModel)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PutAsJsonAsync("https://localhost:7276/api/Comment", updateModel);

            var productres = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");

            ViewBag.Products = productres?.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductID.ToString()
            }).ToList();

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Yorum güncellenemedi.");
                return View(updateModel);
            }

            return RedirectToAction("AdminCommentIndex", "AdminComment", new { area = "AdminArea" });
        }
    }
}
