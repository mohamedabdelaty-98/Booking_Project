using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Booking_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public bool CheckPassword(string password)
        {
            Regex pattern = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=!]).+$");
            return pattern.IsMatch(password);
        }
    }
}
