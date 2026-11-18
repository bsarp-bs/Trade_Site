using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Trade_Site_WebUI_Dto_Layer.UI_Cart_DTOs;
using Trade_Site_WebUI_Dto_Layer.UI_Comment_DTOs;

namespace Trade_Site_WebUI.Controllers
{
    public class CustomerScreenProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerScreenProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult CustomerScreenProductListIndex(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetailIndex(string id)
        {
            ViewBag.x = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentP(UI_AddCommentDto model)   
        {            
            var client = _httpClientFactory.CreateClient();

            model.ImgUrl = "string";
            model.CommentDate = DateTime.Now;

            var response = await client.PostAsJsonAsync("http://localhost:5000/Services/Comments/Comment", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Yorum eklenemedi.");
                return PartialView(model);
            }

            return RedirectToAction("ProductDetailIndex", new { id = model.ProductID });
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(UI_CartItemDto model)
        {
            if(string.IsNullOrEmpty(model.ProductId))
            {
                return BadRequest();
            }

            if (model.Quantity <= 0)
            {
                model.Quantity = 1;
            }


            var token = User.FindFirst("access_token")?.Value;

            if(string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var cart = await client.GetFromJsonAsync<UI_CartTotalDto>("https://localhost:7130/api/Cart");


            if (cart == null)
            {
                cart = new UI_CartTotalDto();
            }

            cart.CartItems ??= new List<UI_CartItemDto>();

            var existingCartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == model.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += model.Quantity;
            }
            else
            {
                cart.CartItems.Add(model);
            }

            var response = await client.PostAsJsonAsync("https://localhost:7130/api/Cart", cart);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return RedirectToAction("CustomerScreenShoppingCartIndex", "CustomerScreenShoppingCart");

        }

    }
}
