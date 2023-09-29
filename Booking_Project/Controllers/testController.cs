using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class testController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
