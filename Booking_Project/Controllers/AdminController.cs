using Booking_Project.Models;
using Booking_Project.Reposatory;
using Booking_Project1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ICrudOperation<Room> RoomRepo;
        private readonly ICrudOperation<Hotel> hotelrepo;

        public AdminController(ICrudOperation<Room> RoomRepo,ICrudOperation<Hotel> hotelRepo)
        {
            this.RoomRepo = RoomRepo;
            this.hotelrepo = hotelRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            List<Room> RoomModel = RoomRepo.GetAll(h=>h.hotel);
           
            return View("room",RoomModel);
        }
        public IActionResult EditRoom(int id)
        {
            Room rs = RoomRepo.GetById(id);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("EditRoom", rs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoom(Room rs, int id)
        {
            if (rs.room_number != null)
            {
                RoomRepo.update(rs);
                RoomRepo.save();
                return RedirectToAction("Rooms");
            }
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("EditRoom", rs);
        }
        public IActionResult DeleteRoom(int id)
        {
            RoomRepo.Delete(id);
            RoomRepo.save();
            return RedirectToAction("Rooms");
        }
        public IActionResult NewRoom()
        {
            //List<Room> RoomModel = RoomRepo.GetAll(h => h.hotel);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("new");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                RoomRepo.insert(room);
                RoomRepo.save();
                return RedirectToAction("Rooms");
            }
            List<Room> RoomModel = RoomRepo.GetAll(h => h.hotel);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("new", room);
        }

    }
}
