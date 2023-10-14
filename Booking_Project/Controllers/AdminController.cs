using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
   // [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public IActionResult Reservations()
        {
            return View("AllReservations");
        }
    }
}
