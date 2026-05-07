using Microsoft.AspNetCore.Mvc;

namespace Trade_Site_WebUI.Areas.AdminArea.ViewComponents
{
    public class _HeaderViewP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
