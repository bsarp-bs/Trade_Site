using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trade_Site_WebUI_Dto_Layer.UI_Category_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_Product_DTOs;

namespace Trade_Site_WebUI.Areas.AdminArea.Controllers
{
    [AllowAnonymous]
    [Area("AdminArea")]
    public class AdminProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
         
        public async Task<IActionResult> AdminProductIndex()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Products";
            ViewBag.v3 = "Product List";
            ViewBag.v4 = "Product List"; 

            var client = _httpClientFactory.CreateClient();

            var products = await client.GetFromJsonAsync<List<UI_ShowProductDto>>("https://localhost:7200/api/Product");
            
            var categories = await client.GetFromJsonAsync<List<UI_ShowCategoryDto>>("https://localhost:7200/api/Category");

            if (categories != null)
            {
                foreach (var item in products)
                {
                    item.CategoryName = categories.FirstOrDefault(x => x.CategoryID == item.CategoryID)?.CategoryName;
                }
            }

            if (products == null)
            {
                return BadRequest();
            }

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var client2 = _httpClientFactory.CreateClient();

            var categories = await client2.GetFromJsonAsync<List<UI_ShowCategoryDto>>("https://localhost:7200/api/Category");

            ViewBag.CategorieList = categories?.Select(x => new SelectListItem
            {
                Value = x.CategoryID.ToString(),
                Text = x.CategoryName

            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(UI_AddProductDto model)
        {
            var client2 = _httpClientFactory.CreateClient();

            var categories = await client2.GetFromJsonAsync<List<UI_ShowCategoryDto>>("https://localhost:7200/api/Category");

            ViewBag.CategorieList = categories?.Select(x => new SelectListItem
            {
                Value = x.CategoryID.ToString(),
                Text = x.CategoryName

            }).ToList();
            
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:7200/api/Product",model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Ürün eklenemedi.");
                return View(model);
            }

            return RedirectToAction("AdminProductIndex", "AdminProduct", new { area = "AdminArea" });
        }

        public async Task<IActionResult> DeleteProduct(string id) 
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.DeleteAsync($"https://localhost:7200/api/Product/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Ürün silinemedi.");
                return RedirectToAction("AdminProductIndex", "AdminProduct", new { area = "AdminArea" });
            }

            return RedirectToAction("AdminProductIndex", "AdminProduct", new { area = "AdminArea" });
        }

        private async Task LoadCategories()
        {
            var client = _httpClientFactory.CreateClient();

            var categories = await client.GetFromJsonAsync<List<UI_ShowCategoryDto>>("https://localhost:7200/api/Category");

            ViewBag.CategorieList = categories?.Select(x => new SelectListItem
            {
                Value = x.CategoryID,
                Text = x.CategoryName
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            await LoadCategories();

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<UI_UpdateProductDto>($"https://localhost:7200/api/Product/{id}");

            if (response == null)
            {
                return BadRequest();
            }

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UI_UpdateProductDto model)
        {
            await LoadCategories();

            var client = _httpClientFactory.CreateClient();

            var response = await client.PutAsJsonAsync("https://localhost:7200/api/Product/", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Ürün güncellenemedi.");
                return View(model);
            }

            return RedirectToAction("AdminProductIndex", "AdminProduct", new { area = "AdminArea" });
        }
    }
}
