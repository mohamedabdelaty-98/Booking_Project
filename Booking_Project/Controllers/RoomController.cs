using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    public class RoomController : Controller
    {
        private readonly ICrudOperation<Room> RoomRepo;

        public RoomController(ICrudOperation<Room> RoomRepo)
        {
            this.RoomRepo = RoomRepo;
            
        }
        public IActionResult Index()
        {
            List<Room> RoomModel = RoomRepo.GetAll();

            return View("Index", RoomModel);
        }
        public IActionResult New()
        {
            //ViewData["Hotels"] = Hotels.GetAll();
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
            //ViewData["Hotels"] = Hotels.GetAll();
            return View("new", room);
        }
        public IActionResult Edit(int id)
        {

            Room rs = RoomRepo.GetById(id);
            //ViewData["Hotels"] = HotelRepo.getAll();
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

            //ViewData["Hotels"] = HotelRepo.getAll();
            return View("Edit", rs);
        }
        public IActionResult Delete(int id)
        {

             RoomRepo.Delete(id);
            return View("Index");
        }
    }
}
