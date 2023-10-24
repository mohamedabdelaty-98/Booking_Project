using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]

        public IActionResult insert()
        {
            ViewData["Rooms"] = room.GetAll();
            ViewData["Amenities"] = amenities.GetAll();
            return PartialView("_InsertAmentiesRoomPartial");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

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
    public IActionResult getAll()
        {
            List<AmenitiesRoom> amenityroom = amenitiesroom.GetAll(a => a.amenities, a => a.room);

            return PartialView("_getallAmentiesroom", amenityroom);
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Edite(int id)
        {

            AmenitiesRoom amenities_room = amenitiesroom.GetById(id);
            ViewData["rooms"] = room.GetById(amenities_room.RoomId);
            ViewData["amenities"] = amenities.GetById(amenities_room.AmentiesId);
            return PartialView("_EditePartial",amenities_room);

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Edite(AmenitiesRoom amenities)
        {
            amenitiesroom.update(amenities);
            amenitiesroom.save();
            return RedirectToAction("index", "admin");
        }
        [Authorize(Roles = "Admin")]

        public IActionResult delete(int id)
        {
            amenitiesroom.Delete(id);
            amenitiesroom.save();
            return RedirectToAction("index", "admin");
        }
    }
}
