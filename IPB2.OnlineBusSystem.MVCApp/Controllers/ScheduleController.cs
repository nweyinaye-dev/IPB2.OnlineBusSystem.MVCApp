using Microsoft.AspNetCore.Mvc;

namespace IPB2.OnlineBusSystem.MVCApp.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
