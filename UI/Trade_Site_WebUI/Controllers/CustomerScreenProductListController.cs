using Microsoft.AspNetCore.Mvc;

namespace Trade_Site_WebUI.Controllers
{
    public class CustomerScreenProductListController : Controller
    {
        public IActionResult CustomerScreenProductListIndex()
        {
            return View();
        }

        public IActionResult ProductDetailIndex()
        {
            return View();
        }
    }
}
