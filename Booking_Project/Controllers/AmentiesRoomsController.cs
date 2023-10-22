using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{

    public class AmentiesRoomsController : Controller
    {
        ICrudOperation<AmenitiesRoom> amenitiesroom;
        ICrudOperation<Amenities> amenities;
        ICrudOperation<Room> room;
        public AmentiesRoomsController(ICrudOperation<AmenitiesRoom> amenitiesroom, ICrudOperation<Room> room, ICrudOperation<Amenities> amenity)
        {
            this.amenitiesroom = amenitiesroom;
            this.amenities = amenity;
            this.room = room;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult insert()
        {
            ViewData["Rooms"]= room.GetAll();
        }
    }
}
