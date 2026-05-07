using Microsoft.AspNetCore.Mvc;

namespace Trade_Site_WebUI.ViewComponents.LayoutViewComponents
{
    public class _HeadP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
