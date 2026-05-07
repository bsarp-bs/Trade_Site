using Microsoft.AspNetCore.Mvc;

namespace Trade_Site_WebUI.Controllers
{
    public class CustomerScreenController : Controller
    {
        public IActionResult CustomerScreenIndex()
        {
            return View();
        }
    }
}
