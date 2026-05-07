using Microsoft.AspNetCore.Mvc;

namespace Trade_Site_WebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult LayoutIndex()
        {
            return View();
        }
    }
}
