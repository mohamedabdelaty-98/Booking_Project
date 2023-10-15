using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class RoomController : Controller
    {
        private readonly ICrudOperation<Room> RoomRepo;
        private readonly ICrudOperation<Hotel> hotelRepo;

        public RoomController(ICrudOperation<Room> RoomRepo, ICrudOperation<Hotel> hotelRepo)
        {
            this.RoomRepo = RoomRepo;
            this.hotelRepo = hotelRepo;
        }
        public IActionResult Index()
        {
            List<Room> RoomModel = RoomRepo.GetAll(h=>h.hotel);

            return View("Index", RoomModel);
        }
        public IActionResult New()
        {
            ViewData["depts"] = hotelRepo.GetAll().ToList();
            return View("new");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Room room)
        {
            if (ModelState.IsValid)
            {
                RoomRepo.insert(room);
                RoomRepo.save();
                return RedirectToAction("Index");
            }
            ViewData["depts"] = hotelRepo.GetAll().ToList();
            return View("new", room);
        }
        public IActionResult Edit(int id)
        {

            Room rs = RoomRepo.GetById(id);
            ViewData["depts"] = hotelRepo.GetAll().ToList();
            return View("Edit", rs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Room rs, int id)
        {
            if (rs.room_number != null)
            {
                RoomRepo.update(rs);
                RoomRepo.save();
                return RedirectToAction("Index");
            }

            ViewData["depts"] = hotelRepo.GetAll().ToList();
            return View("Edit", rs);
        }
        public IActionResult Delete(int id)
        {
             RoomRepo.Delete(id);
            return View("Index");
        }

    }
}
