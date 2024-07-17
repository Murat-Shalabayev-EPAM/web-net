using Microsoft.AspNetCore.Mvc;

namespace Northwind.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var breadcrumbs = new List<BreadcrumbItem>
        {
            new BreadcrumbItem { Title = "Home", Url = Url.Action("Index", "Home") },
            new BreadcrumbItem { Title = ViewContext.RouteData.Values["controller"].ToString(), Url = Url.Action("Index", ViewContext.RouteData.Values["controller"].ToString()) },
            new BreadcrumbItem { Title = ViewContext.RouteData.Values["action"].ToString(), Url = string.Empty }
        };
            return View(breadcrumbs);
        }
    }

    public class BreadcrumbItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
