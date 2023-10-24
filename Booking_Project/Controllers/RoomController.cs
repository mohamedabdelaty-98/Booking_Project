using Booking_Project.Models;
using Booking_Project.Reposatory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Project.Controllers
{
    
    public class RoomController : Controller
    {
        private readonly ICrudOperation<Room> RoomRepo;
        private readonly ICrudOperation<Hotel> hotelrepo;

        public RoomController(ICrudOperation<Room> RoomRepo, ICrudOperation<Hotel> hotelRepo)
        {
            this.RoomRepo = RoomRepo;
            this.hotelrepo = hotelRepo;
        }
        public IActionResult Index()
        {
            //List<Room> RoomModel = RoomRepo.GetAll(h=>h.hotel);

            //return View("Index", RoomModel);
            return View();

        }
        public IActionResult Rooms()
        {
            List<Room> RoomModel = RoomRepo.GetAll(h => h.hotel);

            return PartialView("_roomPartial",RoomModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditRoom(int id)
        {
            Room rs = RoomRepo.GetById(id);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("EditRoom", rs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult EditRoom(Room rs, int id)
        {
            if (rs.room_number != null)
            {
                RoomRepo.update(rs);
                RoomRepo.save();
                return RedirectToAction("index","admin");
            }
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return View("EditRoom", rs);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRoom(int id)
        {
            RoomRepo.Delete(id);
            RoomRepo.save();
            return RedirectToAction("index","admin");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult NewRoom()
        {
            //List<Room> RoomModel = RoomRepo.GetAll(h => h.hotel);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return PartialView("_AddRoomPartial");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult NewRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                RoomRepo.insert(room);
                RoomRepo.save();
                return RedirectToAction("index","admin");
            }
            List<Room> RoomModel = RoomRepo.GetAll(h => h.hotel);
            ViewData["depts"] = hotelrepo.GetAll().ToList();

            return PartialView("_AddRoomPartial");
        }

        //public IActionResult New()
        //{
        //    ViewData["depts"] = hotelRepo.GetAll().ToList();
        //    return View("new");
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Save(Room room)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        RoomRepo.insert(room);
        //        RoomRepo.save();
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["depts"] = hotelRepo.GetAll().ToList();
        //    return View("new", room);
        //}
        //public IActionResult Edit(int id)
        //{

        //    Room rs = RoomRepo.GetById(id);
        //    ViewData["depts"] = hotelRepo.GetAll().ToList();
        //    return View("Edit", rs);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Room rs, int id)
        //{
        //    if (rs.room_number != null)
        //    {
        //        RoomRepo.update(rs);
        //        RoomRepo.save();
        //        return RedirectToAction("Index");
        //    }

        //    ViewData["depts"] = hotelRepo.GetAll().ToList();
        //    return View("Edit", rs);
        //}
        //public IActionResult Delete(int id)
        //{
        //     RoomRepo.Delete(id);
        //    return View("Index");
        //}

    }
}
