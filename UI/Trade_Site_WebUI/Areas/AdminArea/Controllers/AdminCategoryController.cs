using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_WebUI_Dto_Layer.UI_Category_DTOs;

namespace Trade_Site_WebUI.Areas.AdminArea.Controllers
{
    [AllowAnonymous]
    [Area("AdminArea")]
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AdminCategoryIndex()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Categories";
            ViewBag.v3 = "Category List";
            ViewBag.v4 = "Category List";

            var client = _httpClientFactory.CreateClient();
            var value = await client.GetFromJsonAsync<List<UI_ShowCategoryDto>>("https://localhost:7200/api/Category");

            if (value == null)
            {
                return BadRequest();
            }

            return View(value);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(UI_AddCategoryDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7200/api/Category", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Kategori eklenemedi.");
                return View(model);
            }

            return RedirectToAction("AdminCategoryIndex", "AdminCategory", new { area = "AdminArea" });

        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7200/api/Category/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return RedirectToAction("AdminCategoryIndex", "AdminCategory", new { area = "AdminArea" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var value = await client.GetFromJsonAsync<UI_UpdateCategoryDto>($"https://localhost:7200/api/Category/{id}");

            if (value == null)
            {
                return BadRequest();
            }

            return View(value);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UI_UpdateCategoryDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var value = await client.PutAsJsonAsync("https://localhost:7200/api/Category/", model);

            return RedirectToAction("AdminCategoryIndex", "AdminCategory", new { area = "AdminArea" });
        }
    }
}
