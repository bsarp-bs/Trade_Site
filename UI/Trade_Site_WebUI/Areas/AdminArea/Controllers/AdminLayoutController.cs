using Microsoft.AspNetCore.Mvc;

namespace Trade_Site_WebUI.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AdminLayoutController : Controller
    {
        public IActionResult AdminLayoutIndex()
        {
            return View();
        }
    }
}
