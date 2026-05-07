using Microsoft.AspNetCore.Mvc;

namespace Trade_Site_WebUI.Controllers
{
    public class CustomerScreenShoppingCartController : Controller
    {
        public IActionResult CustomerScreenShoppingCartIndex()
        {
            return View();
        }
    }
}
