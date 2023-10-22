using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Booking_Project.Controllers
{

    public class AmenitiesRoomController : Controller
    {
        ICrudOperation<AmenitiesRoom> amenitiesroom;
        ICrudOperation<Amenities> amenities;
        ICrudOperation<Room> room;
        public AmenitiesRoomController(ICrudOperation<AmenitiesRoom> amenitiesroom, ICrudOperation<Room> room, ICrudOperation<Amenities> amenity)
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
            ViewData["Rooms"] = room.GetAll();
            ViewData["Amenities"]=amenities.GetAll();
            return PartialView("_InsertAmentiesRoomPartial");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult insert(AmenitiesRoom amenities_room)
        {
            if (ModelState.IsValid)
            {
                amenitiesroom.insert(amenities_room);
                amenitiesroom.save();
                return RedirectToAction("index", "admin");
            }
            return PartialView("_InsertAmentiesRoomPartial", amenities_room);
        }
    }
}
