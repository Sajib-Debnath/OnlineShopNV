using Microsoft.AspNetCore.Mvc;

namespace OnlineShopNV.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
