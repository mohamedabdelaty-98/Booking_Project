using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using System.Diagnostics;

namespace Booking_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICrudOperation<Hotel> hotelRepo;
        private readonly ICrudOperation<Room> RoomRepo;


        public HomeController( ILogger<HomeController> logger, ICrudOperation<Hotel> hotelRepo, ICrudOperation<Room> RoomRepo)
        {
            _logger = logger;
            this.hotelRepo = hotelRepo;
            this.RoomRepo = RoomRepo;
        }

        public IActionResult Index()
        {
            List<Hotel> hotelModel = hotelRepo.GetAll(h => h.rooms);

            return View("index", hotelModel);
        }
        public IActionResult Rooms(int id)
        {
            List<Room> roomModel = RoomRepo.GetAll(h => h.hotel);
            ViewBag.Id = id;
            return View("Rooms", roomModel);
        }

        public IActionResult book(int id)
        {
            Room roomModel = RoomRepo.GetById(id);
            
            return View("book", roomModel);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}