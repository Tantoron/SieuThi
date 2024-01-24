using Microsoft.AspNetCore.Mvc;

namespace SieuThi.Controllers
{
    public class DangKyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
