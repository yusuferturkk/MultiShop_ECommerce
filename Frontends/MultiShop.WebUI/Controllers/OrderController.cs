using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Sipariş Detayı";
            ViewBag.directory3 = "Ödeme Yap";
            return View();
        }
    }
}
