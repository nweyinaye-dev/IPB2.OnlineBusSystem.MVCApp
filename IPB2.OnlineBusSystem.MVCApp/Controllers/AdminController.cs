using Microsoft.AspNetCore.Mvc;

namespace IPB2.OnlineBusSystem.MVCApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
